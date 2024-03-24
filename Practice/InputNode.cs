using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;

namespace Practice
{
    public class InputNode : GH_ClusterInputHook
    {

        public InputNode()
          : base()
        {
            this.Name = "InputNode";
            this.NickName = "InputNode";
            this.Description = "InputNode";
            this.Category = "ZZ";
            this.SubCategory = "Z";
           // this.WireDisplay = GH_ParamWireDisplay.faint;
        }

/*        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }
*/





        protected override System.Drawing.Bitmap Icon { get { return null; }}
        public override Guid ComponentGuid
        {
            get { return new Guid("4CE80E70-3F72-4E66-BD8D-5B3CF360EFBC"); }
        }
    }
}