using Grasshopper;
using Grasshopper.Kernel;

namespace Practice.ToolBox
{
    public  static class ComponentCounter
    {
        public static int MyModifiedChangedHandler(object sender, GH_Document.ModifiedChangedEventHandler e)
        {
            var ghDoc = Instances.ActiveCanvas.Document;
            if (ghDoc == null) return 0;
            int numberOfComponents = ghDoc.Objects.Count;
            return numberOfComponents;
        }
    }
}
