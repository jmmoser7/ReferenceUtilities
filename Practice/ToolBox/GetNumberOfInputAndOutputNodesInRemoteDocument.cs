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
    internal class GetNumberOfInputAndOutputNodesInRemoteDocument
    {
        //query file path of the active rhino dock on save event


        public int remoteDocCountInput(string filepath)
        {
            bool exists = System.IO.File.Exists(filepath);
            int inputCount = 0;

            if (exists) 
            
            {
                GH_DocumentIO gH_DocumentIO = new GH_DocumentIO();
                gH_DocumentIO.Open(filepath);
                GH_Document gH_Document = gH_DocumentIO.Document;
                
                for (int i = 0; i < gH_Document.Objects.Count; i++)
                {
                    if (gH_Document.Objects[i].ComponentGuid.ToString() == "b4078e0f-d1bf-4966-8fc4-e60acc181f05")
                    {
                        inputCount++;
                    }
                }
            }

            return inputCount;
        }
        public int remoteDocCountOutput(string filepath)
        {
            bool exists = System.IO.File.Exists(filepath);
            int outputCount = 0;

            if (exists)

            {
                GH_DocumentIO gH_DocumentIO = new GH_DocumentIO();
                gH_DocumentIO.Open(filepath);
                GH_Document gH_Document = gH_DocumentIO.Document;

                for (int i = 0; i < gH_Document.Objects.Count; i++)
                {
                    if (gH_Document.Objects[i].ComponentGuid.ToString() == "b4078e0f-d1bf-4966-8fc4-e60acc181f05")
                    {
                        outputCount++;
                    }
                }
            }

            return outputCount;
        }

    }
}
