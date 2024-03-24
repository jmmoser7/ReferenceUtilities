using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using Practice;
using Grasshopper.GUI.Canvas;
using Practice.ToolBox;
using Rhino;
using Rhino.DocObjects;

namespace Practice.ToolBox
{
    internal class QueryActiveRhinoDoc
    {
        //query file path of the active rhino dock on save event
        

        public static string MyModifiedChangedHandler(object sender, DocumentSaveEventArgs e)
        {
            string filePath = RhinoDoc.ActiveDoc.Path;
            return filePath;                   
        }

    }
}
