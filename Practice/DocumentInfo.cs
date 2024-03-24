/*using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using Practice;
using Grasshopper.GUI.Canvas;
using Practice.ToolBox;
using Rhino;

namespace Practice
{
    public class DocumentInfo : GH_Component
    {

        public DocumentInfo() : base
                (
                "ComponentCounter",
                "Count",
                "Returns The Number of components in the active cocument",
                "ZZ", 
                "Z"
                )
        {
            if (Instances.ActiveCanvas == null) return;
            Instances.ActiveCanvas.Document_ObjectsAdded += OnObjectChanged;
            Instances.ActiveCanvas.Document_ObjectsDeleted += OnObjectChanged;
        }

        private void OnObjectChanged(GH_Document sender, GH_DocObjectEventArgs e)
        {
            this.ExpireSolution(false);
        }


        // Register for events when the component is added to the canvas


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {         
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.Register_GenericParam("Number of components", "n", "Integer", GH_ParamAccess.item);
            pManager.Register_GenericParam("Component Names", "n", "List of strings", GH_ParamAccess.list);
            pManager.Register_GenericParam("Active Plugins", "n", "List of strings", GH_ParamAccess.list);
            pManager.Register_GenericParam("Active Rhino Doc", "n", "String", GH_ParamAccess.item);
        }
        


            protected override void SolveInstance(IGH_DataAccess DA)
        {
            #region  
            // get the number of components on the canvas
            int numberOfComponents = ComponentCounter.MyModifiedChangedHandler(this, null);

            //QueryActivePlugins.GetDocumentNumbers();
            // recomputes the component
            //this.ExpireSolution(true);
            // set the output

            //var queryObject = new QueryActivePlugins();
            //queryObject.GetDocumentNumbers();
           // int numberOfComponents = QueryActivePlugins.ComponentCount;
            DA.SetData("Number of components", numberOfComponents);
            #endregion

            #region
            // get the names of all the components on the canvas
            List<string> componentNames = GetAllComponentNames.MyModifiedChangedHandler(this, null);
            // recomputes the component
            // this.ExpireSolution(true);
            // set the output
            DA.SetDataList("Component Names", componentNames);
            #endregion

            #region
            // query the active plugins
            List<string> activePlugins = QueryActivePlugins.GetDocumentNumbers(); 
            // recomputes the component
            // this.ExpireSolution(true);
            // set the output
            DA.SetDataList("Active Plugins", activePlugins);
            #endregion

            #region
            // query the active rhino doc            
            string filePath = QueryActiveRhinoDoc.MyModifiedChangedHandler(this, null);
            // recomputes the component if value changes   
            //this.ExpireSolution(true);
            // set the output 
            DA.SetData("Active Rhino Doc", filePath);
                        #endregion
        }
        protected override System.Drawing.Bitmap Icon => null;


        public override Guid ComponentGuid => new Guid("0032f6b7-2c03-4196-9720-10ae7d029f00");
    }
}*/