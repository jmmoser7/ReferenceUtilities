using Grasshopper.GUI;
using Grasshopper.Kernel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System;
using System.Diagnostics.Eventing.Reader;

namespace Practice.ToolBox
{
    public class Startup : GH_AssemblyPriority
    {
        public Startup() : base() { }

        public override GH_LoadingInstruction PriorityLoad()
        {
            Task.Run(() => OnStartup());
            return GH_LoadingInstruction.Proceed;
        }

        private void OnStartup()
        {
            GH_DocumentEditor editor = null;
            while (editor == null)
            {
                editor = Grasshopper.Instances.DocumentEditor;
                Thread.Sleep(200);
            }

            // Attach the KeyDown event handler once the editor is available
            editor.KeyDown += DocumentEditor_KeyDown;

            // Now that we're on the main thread, we can modify the UI
            editor.Invoke((MethodInvoker)delegate { Populate(editor.MainMenuStrip); });
        }

        private void Populate(MenuStrip mainMenuStrip)
        {
            var title = "HoneyBadger";
            var menuItems = mainMenuStrip.Items.Find(title, false);

            ToolStripMenuItem menu;
            if (menuItems.Length == 0)
                menu = new ToolStripMenuItem(title);
            else
                menu = menuItems[0] as ToolStripMenuItem;

            mainMenuStrip.Items.Add(menu);
            PopulateSub(menu);
        }

        private void PopulateSub(ToolStripMenuItem menu)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Simplify Selected Component Inputs");
            menu.DropDownItems.Add(menuItem);
            menuItem.Click += MenuClicked;
            // Assigning shortcut keys like Alt + Shift + S
            menuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
        }
        private void MenuClicked(object sender, EventArgs e)
        {
            SimplifySelectedComponents();
        }

        private static void DocumentEditor_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the correct combination of keys is pressed
            if (e.Control && e.Alt && e.KeyCode == Keys.S)
            {
                SimplifySelectedComponents();
            }
        }

        private static void SimplifySelectedComponents()
        {
            // Access the active canvas and iterate over selected objects
            var document = Grasshopper.Instances.ActiveCanvas.Document;
            if (document != null)
            {
                foreach (IGH_DocumentObject obj in document.Objects)
                {
                    if (obj.Attributes.Selected)
                    {
                        // Cast the object to IGH_Component to access its parameters
                        if (obj is IGH_Component component)
                        {
                            // Check if all parameters are simplified
                            bool allSimplified = true;
                            foreach (IGH_Param param in component.Params.Input)
                            {
                                if (param != null && !param.Simplify)
                                {
                                    allSimplified = false;
                                    break;
                                }
                            }

                            // Only unsimplify if all parameters are simplified
                            if (allSimplified)
                            {
                                foreach (IGH_Param param in component.Params.Input)
                                {
                                    if (param != null)
                                    {
                                        param.Simplify = false;
                                    }
                                }
                                // Expire the solution to update the component
                                obj.ExpireSolution(true);
                            }
                            else
                            {
                                foreach (IGH_Param param in component.Params.Input)
                                {
                                    if (param != null)
                                    {
                                        param.Simplify = true;
                                    }
                                }

                                // Expire the solution to update the component
                                obj.ExpireSolution(true);
                            }
                        }
                    }
                }
            }
        }

    }
}
