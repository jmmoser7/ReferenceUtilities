using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Practice.ToolBox;
using Rhino.Geometry;


namespace Practice
{
    public class OutputNode : GH_ClusterOutputHook
    {

        public OutputNode()
          : base()
        {
            this.Name = "OutputNode";
            this.NickName = "OutputNode";
            this.Description = "OutputNode";
            this.Category = "ZZ";
            this.SubCategory = "Z";
            // this.WireDisplay = GH_ParamWireDisplay.faint;
        }
  

        protected override System.Drawing.Bitmap Icon { get { return null; } }
        public override Guid ComponentGuid
        {
            get { return new Guid("B4078E0F-D1BF-4966-8FC4-E60ACC181F05"); }
        }
    }
}