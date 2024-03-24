using System;
using System.Collections.Generic;
using Grasshopper.Kernel.Parameters;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using Practice.ToolBox;
using System.Linq;

namespace Practice
{
    public class ExtensibleComponent : GH_Component, IGH_VariableParameterComponent
    {
        int inCount = 0;
        int outCount = 0;

        public ExtensibleComponent()
          : base("ExtensibleComponent", "EC", "", "ZZ", "Z") { }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {


        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

        }






        string selectedFilePath = null;
        protected override void AppendAdditionalComponentMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalComponentMenuItems(menu);

            // Append a new menu item that will open the file dialog when clicked
            Menu_AppendItem(menu, "Select File", Menu_SelectFileClicked);
        }

        // This method will be called when the menu item is clicked
        private void Menu_SelectFileClicked(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog
            var fileDialog = new OpenFileDialog();

            // Set the properties on the OpenFileDialog
            fileDialog.Filter = "All files (*.*)|*.*"; // or set specific file types
            fileDialog.Title = "Select a file";

            // Show the dialog and react accordingly
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = fileDialog.FileName;
                ExpireSolution(true);
            }
        }


        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string filePath = selectedFilePath;

            GetNumberOfInputAndOutputNodesInRemoteDocument getCount = new GetNumberOfInputAndOutputNodesInRemoteDocument();

            inCount = getCount.remoteDocCountInput(filePath);
            outCount = getCount.remoteDocCountOutput(filePath);

            if (filePath != null) { Load(inCount, outCount); }
        }


        int inputIndex = 0;

        bool IGH_VariableParameterComponent.CanInsertParameter(GH_ParameterSide side, int index) { return false; }
        bool IGH_VariableParameterComponent.CanRemoveParameter(GH_ParameterSide side, int index) { return false; }
        public IGH_Param CreateParameter(GH_ParameterSide side, int index) { return null; }
        public bool DestroyParameter(GH_ParameterSide side, int index) { return false; }
        public void VariableParameterMaintenance()
        {
        }





        private void Load(int count1, int count2)
        {
            for (int i = 0; i < count1; i++)
            {
                Param_Number pn2 = new Param_Number
                {
                    Name = i.ToString(),
                    NickName = "t",
                    Description = "Tolernece",
                    Access = GH_ParamAccess.item,
                    Optional = true
                };
                Params.RegisterInputParam(pn2, i + 1);
                Params.OnParametersChanged();
            }

            for (int i = 0; i < count2; i++)
            {
                Param_Number pn2 = new Param_Number
                {
                    Name = i.ToString(),
                    NickName = "t",
                    Description = "Tolernece",
                    Access = GH_ParamAccess.item,
                    Optional = true
                };
                Params.RegisterOutputParam(pn2, i + 1);
                Params.OnParametersChanged();
            }

        }

        protected override System.Drawing.Bitmap Icon { get { return null; } }
        public override Guid ComponentGuid { get { return new Guid("DC84E6D5-4A82-4BC0-BF65-BE5B3E55B0E8"); } }
    }
}