using System;
using Grasshopper.GUI.Canvas;
using Grasshopper.GUI;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using Rhino.Geometry;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using Practice.ToolBox;

namespace Practice
{
    public class CustomButtonComponent : GH_Component
    {
        public CustomButtonComponent()
          : base() 
        {
            this.Name = "CustomButtonComponent";
            this.NickName = "CustomButtonComponent";
            this.Description = "CustomButtonComponent";
            this.Category = "ZZ";
            this.SubCategory = "Z";             
        }


  
        private List<List<string>> allFiles = new List<List<string>>(){};
        // register input parameters

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager) 
        {
           
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        { 
            
        }
        protected override void SolveInstance(IGH_DataAccess DA) 
        {

        }

        public override void CreateAttributes()
        {
            // Assign custom attributes to the component
            m_attributes = new Attributes_Custom(this);
           // m_attributes = new BlackComponentAttributes(this);
        }





        protected override System.Drawing.Bitmap Icon
        {
            get { return null; }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("67DA049F-EF62-4D74-8E12-619D903BF690"); }
        }
    }

   
}
