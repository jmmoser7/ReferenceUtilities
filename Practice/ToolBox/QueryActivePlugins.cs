using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using Practice;
using Grasshopper.GUI.Canvas;
using Practice.ToolBox;
using Rhino;

namespace Practice.ToolBox
{
    public static class QueryActivePlugins

    {
        public static int ComponentCount = 0;

        public static  List<string> GetDocumentNumbers()
        {
            var ghDoc = Instances.ActiveCanvas.Document;
            if (ghDoc == null) return null;
            List<string> componentNames = new List<string>();
            foreach (IGH_DocumentObject obj in ghDoc.Objects)
            {
                componentNames.Add(obj.Category);

            }
            //create a list of unique items
            List<string> uniqueItems = new List<string>();
            foreach (string item in componentNames)
            {
                if (!uniqueItems.Contains(item))
                {
                    uniqueItems.Add(item);
                }
            }
            //create counter for each unique item
            List<int> counter = new List<int>();
            foreach (string item in uniqueItems)
            {
                int count = 0;
                foreach (string item2 in componentNames)
                {
                    if (item == item2)
                    {
                        count++;
                    }
                }
                counter.Add(count);
            }  
            //create a list of strings with the unique item and the number of times it appears  
                List<string> uniqueItemsAndCount = new List<string>();
            for (int i = 0; i < uniqueItems.Count; i++)
            {
                uniqueItemsAndCount.Add(uniqueItems[i] + " " + counter[i]);
            }
            ComponentCount = componentNames.Count;

            return uniqueItemsAndCount;
            
        }
    }
}
