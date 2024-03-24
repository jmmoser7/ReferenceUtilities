/*using System;
using System.Drawing; // Make sure to include System.Drawing for the Color type
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using Grasshopper.Kernel.Attributes;
using System.Diagnostics.Eventing.Reader;
using Eto.Threading;

namespace Practice
{
    public class ColorSwitchingComponent : GH_Component
    {
        private Color _componentColor = Color.Transparent; // Default to transparent until a color is set

        public ColorSwitchingComponent()
          : base(
                "ColorSwitchingComponent",
                "Nickname",
                "Description",
                "ZZ",
                "Z"
                )
        {
        }
        public override void CreateAttributes()
        {
            m_attributes = new CustomAttributes(this);
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddColourParameter("Color", "C", "Color to change the component's display", GH_ParamAccess.item,Color.Blue);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Color", "C", "The color in text format.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Retrieve the color from the input parameter
            Color inputColor = Color.Transparent;
            if (DA.GetData(0, ref inputColor))
            {
               DA.SetData(0, inputColor.ToString());
         
            }

        }

        public class CustomAttributes : GH_ComponentAttributes
        {
            public CustomAttributes(IGH_Component component)
              : base(component)
            { }

            protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
            {
                if (channel == GH_CanvasChannel.Objects)
                {
                    // Cache the existing style.
                    GH_PaletteStyle style = GH_Skin.palette_normal_standard;

                    // Swap out palette for normal, unselected components.
                    GH_Skin.palette_normal_standard = new GH_PaletteStyle(Color.DeepPink, Color.Teal, Color.PapayaWhip);

                    base.Render(canvas, graphics, channel);

                    // Put the original style back.
                    GH_Skin.palette_normal_standard = style;
                }
                else

                    base.Render(canvas, graphics, channel);
            }
        }

        protected override System.Drawing.Bitmap Icon { get { return null; } }
        public override Guid ComponentGuid { get { return new Guid("704675A1-EB1E-4463-876D-6479E865778B"); } }
        public Color ComponentColor { get { return _componentColor; } }

    }

}






*/
using System;
using System.Drawing;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;

namespace Practice
{
    public class ColorSwitchingComponent : GH_Component
    {
        private Color _componentColor = Color.Transparent;

        public ColorSwitchingComponent()
          : base("ColorSwitchingComponent", "Nickname", "Description", "ZZ", "Z")
        {
        }

        public override void CreateAttributes()
        {
            m_attributes = new CustomAttributes(this);
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddColourParameter("Color", "C", "Color to change the component's display", GH_ParamAccess.item, Color.Blue);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Color", "C", "The color in text format.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (DA.GetData(0, ref _componentColor))
            {
                DA.SetData(0, _componentColor.ToString());
            }
        }

        public class CustomAttributes : GH_ComponentAttributes
        {
            private ColorSwitchingComponent _parent;

            public CustomAttributes(ColorSwitchingComponent component) : base(component)
            {
                _parent = component;
            }

            protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
            {
                if (channel == GH_CanvasChannel.Objects)
                {
                    // Set your component's color
                    var style = new GH_PaletteStyle(_parent._componentColor, _parent._componentColor, _parent._componentColor);
                    var originalStyle = GH_Skin.palette_normal_standard;

                    GH_Skin.palette_normal_standard = style;
                    base.Render(canvas, graphics, channel);
                    base.dra
                    GH_Skin.palette_normal_standard = originalStyle;
                }
                else
                {
                    base.Render(canvas, graphics, channel);
                }
            }
        }

        protected override System.Drawing.Bitmap Icon => null;
        public override Guid ComponentGuid => new Guid("704675A1-EB1E-4463-876D-6479E865778B");
    }
}
