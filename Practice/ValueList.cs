using System;
using System.Collections.Generic;
using System.Linq;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino;
using Rhino.Geometry;

namespace Practice
{
    public class ValueList : GH_ValueList
    {
        /// <summary>
        /// Initializes a new instance of the ValueList class.
        /// </summary>
        public ValueList()
          : base()
        {
            this.Name = "ValueList";
            this.NickName = "ValueList";
            this.Description = "ValueList";
            this.Category = "ZZ";
            this.SubCategory = "Z";
            this.ListMode = GH_ValueListMode.CheckList;
            this.ListItems.Clear();

            //get block names from active rhino doc

            //TODO: Implement a new algorithm here



            this.ListItems.Add(new GH_ValueListItem("Item 7", "7"));
            this.ListItems.Add(new GH_ValueListItem("Item 8", "8"));
            this.ListItems.Add(new GH_ValueListItem("Item 9", "9"));
            

            
           
        }
        public void AddItems(List<string> items)
        {
            foreach (string item in items)
            {
                this.ListItems.Add(new GH_ValueListItem(item, item));
            }
        }
        
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("304B3E0C-83DA-47F4-8D5B-D689CD027B57"); }
        }
    }
}