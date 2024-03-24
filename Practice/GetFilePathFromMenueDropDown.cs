using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using System.Windows.Forms;
using Rhino.Geometry;

namespace Practice
{
    public class GetFilePathFromMenueDropDown : GH_Component
    {

        public GetFilePathFromMenueDropDown()
          : base(
                "OpenFileFromMenueDropDown",
                "Nickname",
                "Description",
                "ZZ",
                "Z"
                )
        {
        }
        string selectedFilePath = null;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager) { }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager) 
        {
            pManager.AddTextParameter("Path", "P", "Path", GH_ParamAccess.item);
        }


        protected override void AppendAdditionalComponentMenuItems(ToolStripDropDown menu)
        {
            base.ClearData();
            base.AppendAdditionalComponentMenuItems(menu);
            Menu_AppendItem(menu, "Select File", Menu_SelectFileClicked);
        }
        private void Menu_SelectFileClicked(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files (*.*)|*.*";  
            fileDialog.Title = "Select a file";

            if (fileDialog.ShowDialog() == DialogResult.OK )
            {
                selectedFilePath = fileDialog.FileName;
            }
            ExpireSolution(true);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            DA.SetData(0, selectedFilePath);
        }


        protected override System.Drawing.Bitmap Icon { get { return null; } }

        public override Guid ComponentGuid
        {
            get { return new Guid("5F7E7CFE-A90A-4921-A5E2-5073B764891D"); }
        }
    }
}