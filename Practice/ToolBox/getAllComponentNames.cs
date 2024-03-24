using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using Practice;
using Grasshopper.GUI.Canvas;
using Practice.ToolBox;
using Rhino;
using Grasshopper.GUI;
using Grasshopper.Kernel.Attributes;
using Grasshopper.Kernel.Parameters;


namespace Practice.ToolBox
{
    internal class GetAllComponentNames
    {
        public static List<string> MyModifiedChangedHandler(object sender, GH_Document.ModifiedChangedEventHandler e)
        {
            var ghDoc = Instances.ActiveCanvas.Document;
            
            if (ghDoc == null) return null;
            List<string> componentNames = new List<string>();
            foreach (IGH_DocumentObject obj in ghDoc.Objects)
            {
               // simplify the input tree structure of the component
                if (obj is IGH_Param)
                {
                    IGH_Param param = obj as IGH_Param;
                    param.Access = GH_ParamAccess.item;
                    param.Simplify = true;
                }      




                componentNames.Add(obj.NickName);
            }
            return componentNames;
        }
    }
}
