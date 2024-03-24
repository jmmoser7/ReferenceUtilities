using System;
using System.IO;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Practice.ToolBox;

namespace Practice
{
    public class QueryFilePaths : GH_Component
    {

        public QueryFilePaths()
          : base(
                "QueryFilePaths",
                "Nickname",
                "Description",
                "ZZ",
                "Z"
                )
        {
        }


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            //input string for file path
            pManager.Register_StringParam("File Path", "F", "File Path", GH_ParamAccess.item);
            //input boolean to triger event
            pManager.Register_BooleanParam("Trigger", "T", "Trigger", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            //output list of files in folder
            pManager.Register_GenericParam("File Names", "F", "File Names", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //query file names in directory
            string filePath = null;
            bool trigger = false;
            List<string> fileNames = new List<string>();

            DA.GetData<string>("File Path", ref filePath);
            DA.GetData<bool>("Trigger", ref trigger);

            //call the ReportFilesInFolder class
            ReportFilesInFolder reportFiles = new ReportFilesInFolder();
            fileNames =  reportFiles.GetFilePaths(filePath, trigger);
                
            DA.SetDataList("File Names", fileNames);
        }
        
        protected override System.Drawing.Bitmap Icon { get { return null; } }

        public override Guid ComponentGuid { get { return new Guid("41AAF155-17D1-4BE7-B9BF-8B6D401BF7CA"); } }
    }
}