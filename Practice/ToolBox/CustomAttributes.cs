/*using Grasshopper.GUI.Canvas;
using Grasshopper.GUI;
using Grasshopper.Kernel;
using System.Windows.Forms;

namespace Practice.ToolBox
{
    public class Attributes_Custom : Grasshopper.Kernel.Attributes.GH_ComponentAttributes
    {
        public Attributes_Custom(GH_Component owner) : base(owner) { }

        protected override void Layout()
        {
            base.Layout();

            System.Drawing.Rectangle rec0 = GH_Convert.ToRectangle(Bounds);
            rec0.Height += 10;

            System.Drawing.Rectangle rec1 = rec0;
            rec1.Y = rec1.Bottom - 22;
            rec1.Height = 22;
            rec1.Inflate(-2, -2);

            Bounds = rec0;
            
            ButtonBounds = rec1;
        }
        private System.Drawing.Rectangle ButtonBounds { get; set; }

        protected override void Render(GH_Canvas canvas, System.Drawing.Graphics graphics, GH_CanvasChannel channel)
        {
            base.Render(canvas, graphics, channel);
            

            if (channel == GH_CanvasChannel.Objects)
            {                
               //GH_Capsule node = GH_Capsule.CreateCapsule(Bounds, GH_Palette.Transparent);
                GH_Capsule button = GH_Capsule.CreateTextCapsule(ButtonBounds, ButtonBounds, GH_Palette.Black, "Button", 2, 0);
                button.Render(graphics, Selected, Owner.Locked, false);
                button.SetJaggedEdges(false, false);
                button.Palette = GH_Palette.Black;
                //node.Render(graphics, Selected, Owner.Locked, false);
                //node.SetJaggedEdges(false, false);
                
                button.Dispose();
            }
        }
        
        public override GH_ObjectResponse RespondToMouseDown(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                System.Drawing.RectangleF rec = ButtonBounds;
                if (rec.Contains(e.CanvasLocation))
                {
                    MessageBox.Show("The button was clicked", "Button", MessageBoxButtons.OK);
                    return GH_ObjectResponse.Handled;
                }
            }
            return base.RespondToMouseDown(sender, e);
        }
    }
}
*/

using Grasshopper.GUI.Canvas;
using Grasshopper.GUI;
using Grasshopper.Kernel;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Practice.ToolBox
{
    public class Attributes_Custom : Grasshopper.Kernel.Attributes.GH_ComponentAttributes
    {
        public Attributes_Custom(GH_Component owner) : base(owner) { }

        protected override void Layout()
        {
            base.Layout();

            System.Drawing.Rectangle rec0 = GH_Convert.ToRectangle(Bounds);
            rec0.Height += 10;
            // Increase the height for the button

            System.Drawing.Rectangle rec1 = rec0;
            rec1.Y = rec1.Bottom - 22;  // Position for the button
            rec1.Height = 22;  // Height for the button
            rec1.Inflate(-2, -2);  // Shrink the button's rectangle slightly for padding

            Bounds = rec0;
            ButtonBounds = rec1;
        }
        private System.Drawing.Rectangle ButtonBounds { get; set; }


        
        

        

        /*        protected override void Render(GH_Canvas canvas, System.Drawing.Graphics graphics, GH_CanvasChannel channel)
                {
                    base.Render(canvas, graphics, channel);

                    if (channel == GH_CanvasChannel.Objects)
                    {
                        // Create a black capsule for the component
                        GH_Capsule node = GH_Capsule.CreateCapsule(Bounds, GH_Palette.Black);
                        // Render the node (component's capsule)
                        node.Render(graphics, Selected, Owner.Locked, false);

                        // Create a black capsule for the button
                        GH_Capsule button = GH_Capsule.CreateTextCapsule(ButtonBounds, ButtonBounds, GH_Palette.Black, "Button", 2, 0);
                        // Render the button
                        button.Render(graphics, Selected, Owner.Locked, false);
                        // Ensure the button does not have jagged edges
                        button.SetJaggedEdges(false, false);

                        // Clean up resources used by the button
                        button.Dispose();
                        // Clean up resources used by the node
                        node.Dispose();
                    }
                }*/

        protected override void Render(GH_Canvas canvas, System.Drawing.Graphics graphics, GH_CanvasChannel channel)
        {
            base.Render(canvas, graphics, channel);

            if (channel == GH_CanvasChannel.Objects)
            {
               // System.Drawing.Graphics g = canvas.Graphics;
                // Create a black capsule for the component with non-jagged edges
               // var ted = GH_BorderTopology.All;
                GH_Capsule node = GH_Capsule.CreateCapsule(Bounds, GH_Palette.Black);
               // node.SetJaggedEdges(false, false); // This ensures the main component edges are not jagged
               // node.Render(graphics, Selected, Owner.Locked, false); // Render the node (component's capsule)
                
                // Create a text capsule for the button with non-jagged edges
                GH_Capsule button = GH_Capsule.CreateTextCapsule(ButtonBounds, ButtonBounds, GH_Palette.Black, "Button", 2, 0);
               // button.SetJaggedEdges(false, false); // This ensures the button edges are not jagged
                button.Render(graphics, Selected, Owner.Locked, false); // Render the button

                // Clean up resources used by the button and node to prevent memory leaks
                button.Dispose();
                node.Dispose();
                
            }
        }

        public override GH_ObjectResponse RespondToMouseDown(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                System.Drawing.RectangleF rec = ButtonBounds;
                if (rec.Contains(e.CanvasLocation))
                {
                    MessageBox.Show("The button was clicked", "Button", MessageBoxButtons.OK);
                    return GH_ObjectResponse.Handled;  // Indicate that the click was handled
                }
            }
            return base.RespondToMouseDown(sender, e);
        }
    }
}
