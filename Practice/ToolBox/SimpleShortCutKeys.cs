/*using Grasshopper.GUI;
using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Practice.ToolBox
{
    internal class SimpleShortCutKeys : GH_AssemblyPriority
    {
        public SimpleShortCutKeys() : base() { }

        public override GH_LoadingInstruction PriorityLoad()
        {
            Task task = new Task(OnStartup);
            task.Start();

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
            Populate(editor.MainMenuStrip);
        }

        private void Populate(MenuStrip mms)
        {
            var tl = "TopLevel";
            //Can not find anything
            var s = mms.Items.Find(tl, false);

            ToolStripMenuItem menu;
            if (s.Length == 0)
                menu = new ToolStripMenuItem(tl);
            else
                menu = s[0] as ToolStripMenuItem;
            mms.Items.Add(menu);
            PopulateSub(menu);
        }

        private void PopulateSub(ToolStripMenuItem menu)
        {
            var main = new ToolStripMenuItem("Sub1");
            menu.DropDownItems.Add(main);
        }
    }




}
*/