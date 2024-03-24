using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Practice
{
    public class MenuDropDown : GH_Component
    {

        public MenuDropDown() : base("MenuDropDown", "Nickname", "Description", "ZZ", "Z") { }


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager) { }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager) { }

        protected override void SolveInstance(IGH_DataAccess DA) { }



        protected override void AppendAdditionalComponentMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalComponentMenuItems(menu);

            var ted = Menu_AppendItem(menu, "JIM");
            var bob = Menu_AppendItem(menu, "BOB");
            var jim = Menu_AppendItem(menu, "TED");

        }
        protected override System.Drawing.Bitmap Icon { get { return null; } }

        public override Guid ComponentGuid
        {
            get { return new Guid("2FE0BD07-A4C2-4E5E-AC6E-2D5B807FD30A"); }
        }
    }
}