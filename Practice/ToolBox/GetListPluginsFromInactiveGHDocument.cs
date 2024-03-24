using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;

namespace Practice.ToolBox
{
    internal class GetListPluginsFromInactiveGHDocument
    {
        //string filePath = null;
        List<string> ComponentNames = new List<string>();
        //GH_DocumentIO io = new GH_DocumentIO();
        public List<String> returnAllComponentsInDocument(string inputFilePath) 
        {
            var io = new GH_DocumentIO();
            io.Open(inputFilePath);
            GH_Document doc = io.Document;

            if (doc == null) return null;

            foreach(IGH_DocumentObject obj in doc.Objects) 
            
            {
                ComponentNames.Add(obj.Name);       
                
                ComponentNames.Add(obj.Attributes.ToString());
                ComponentNames.Add("                        ");
            }
            return ComponentNames;
        }              

    }
}
