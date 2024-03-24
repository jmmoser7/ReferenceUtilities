using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Practice.ToolBox;
using Rhino.Geometry;

namespace Practice
{
    public class GetFileInfo : GH_Component
    {

        public GetFileInfo()
          : base
               ("GetFileInfo",
                "Nickname",
                "Description",
                "ZZ",
                "Z"
                )
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("File Path", "F", "File Path", GH_ParamAccess.item);  

        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ComponentNames", "cn", "", GH_ParamAccess.list);

        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //Report Component Names in Inactive GH Document
            #region
            string filePath = null;
            DA.GetData<string>("File Path", ref filePath);
            List<string> componentNames = null;
            GetListPluginsFromInactiveGHDocument getPlugins = new GetListPluginsFromInactiveGHDocument();
            componentNames = getPlugins.returnAllComponentsInDocument(filePath);
            DA.SetDataList(0, componentNames);
            #endregion

        }

        protected override System.Drawing.Bitmap Icon { get { return null; } }


        public override Guid ComponentGuid { get { return new Guid("DDD5C0DE-9162-42C4-AEEF-80C28217985F"); } }
    }
}