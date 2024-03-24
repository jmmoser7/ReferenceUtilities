using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace Practice
{
    public class PracticeInfo : GH_AssemblyInfo
    {
        public override string Name => "Practice";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("cdfcc805-006d-40a4-b5c6-fd421a703b16");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}