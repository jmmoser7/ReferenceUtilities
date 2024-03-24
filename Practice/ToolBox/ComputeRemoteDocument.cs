using Grasshopper.Kernel;
using Grasshopper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel.Parameters;
using Rhino.Geometry;
using Grasshopper.Kernel.Special;

namespace Practice.ToolBox
{
    internal class ComputeRemoteDocument
    {
        public void RunScript(string File, object Input, ref GH_ClusterOutputHook output)
        {
            var io = new GH_DocumentIO();
            io.Open(File);

            GH_Document doc = io.Document;
            if (doc == null)
                throw new Exception("File could not be opened.");

            // Set input data to parameter called "INPUT".
            foreach (IGH_DocumentObject obj in doc.Objects)
            {
                if (obj.NickName != "INPUT") continue;
                var param = obj as IGH_Param;
                if (param == null) continue;

                var arguments = new List<object>();
                arguments.Add(Input);

                Grasshopper.Utility.InvokeMethod(param, "Script_ClearPersistentData");
                Grasshopper.Utility.InvokeMethod(param, "Script_AddPersistentData", arguments);
            }

            doc.Enabled = true;
            doc.NewSolution(true, GH_SolutionMode.Silent);

            // Harvest output value from parameter named "OUTPUT".
            foreach (IGH_DocumentObject obj in doc.Objects)
            {
                if (obj.NickName != "OUTPUT") continue;
                var param = obj as IGH_Param;
                if (param == null) continue;

                var structure = param.VolatileData;
                var tree = new DataTree<object>();
                var hint = new Grasshopper.Kernel.Parameters.Hints.GH_NullHint();
                tree.MergeStructure(param.VolatileData, hint);

                //return tree;
                //break;
            }

            doc.Dispose();
        }



    }
}
