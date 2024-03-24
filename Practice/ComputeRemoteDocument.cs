using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Practice.ToolBox;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Parameters;
using Grasshopper;
using System.Linq;

namespace Practice
{
    public class ComputeRemoteDocument : GH_Component
    {

        public ComputeRemoteDocument()
          : base(
                "ComputeRemoteDocument",
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
            pManager.AddNumberParameter("Number", "N", "Number", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            //pManager.AddCurveParameter("Curve", "C", "Curve", GH_ParamAccess.tree);
            pManager.AddGenericParameter("Data", "D", "Data", GH_ParamAccess.tree);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //Computer Curve from Inactive GH Document
            
            string filePath = null;
            DA.GetData<string>("File Path", ref filePath);

            double number = 0;
            DA.GetData<double>("Number", ref number);         

            var io = new GH_DocumentIO();
            io.Open(filePath);
            var doc = io.Document;

            if (doc == null) { throw new Exception("file path is not valid"); }


            // Set input data to parameter called "INPUT".
            foreach (IGH_DocumentObject obj in doc.Objects)
            {
                if (obj.NickName != "INPUT") continue;
                var param = obj as IGH_Param;
                if (param == null) continue;

                var arguments = new List<object>();
                arguments.Add(number);

                Grasshopper.Utility.InvokeMethod(param, "Script_ClearPersistentData");
                Grasshopper.Utility.InvokeMethod(param, "Script_AddPersistentData", arguments);
            }


            doc.Enabled = true;
            doc.NewSolution(true, GH_SolutionMode.Silent);            
            DataTree<Curve> curves = new DataTree<Curve>();            
            var tree = new DataTree<object>();

            //get output data from parameter called "OUTPUT".
            foreach (IGH_DocumentObject obj in doc.Objects)
                        {
                            if (obj.NickName != "OUTPUT") continue;
                            var param = obj as IGH_Param;
                            if (param == null) continue;

                            var structure = param.VolatileData;
                            var hint = new Grasshopper.Kernel.Parameters.Hints.GH_NullHint();
                            tree.ClearData();
                            tree.MergeStructure(param.VolatileData, hint);                             
                            break;
                        }


            DA.SetDataTree(0, tree);
        }     
        
        
        
        protected override System.Drawing.Bitmap Icon { get { return null; } }
        public override Guid ComponentGuid
        {
            get { return new Guid("BCCFE460-3B0F-4DA4-8105-265019A3724C"); }
        }
    }
}