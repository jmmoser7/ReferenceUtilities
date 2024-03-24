using Grasshopper.Kernel;
using System.Drawing;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel.Attributes;

namespace Practice.ToolBox

{ 
    public class BlackComponentAttributes : GH_ComponentAttributes
    {
        public BlackComponentAttributes(IGH_Component owner) : base(owner) { }

        protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
        {
            if (channel == GH_CanvasChannel.Objects)
            {
                // Set the component to be drawn with a black background
                GH_Capsule capsule = GH_Capsule.CreateCapsule(this.Bounds, GH_Palette.Black, 2, 0);
                capsule.Render(graphics, Selected, Owner.Locked, false);
                capsule.Dispose();

                // Render the text and other standard decorations
                base.Render(canvas, graphics, channel);
            }
        }
    }

}
