using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;

namespace Practice
{
    public class ButtonStuff : GH_ButtonObject
    {

        public ButtonStuff()
          : base(

                )
        {
            this.Name = "ButtonStuff";
            this.NickName = "ButtonStuff";
            this.Description = "ButtonStuff";
            this.Category = "ZZ";
            this.SubCategory = "Z";

            this.WireDisplay = GH_ParamWireDisplay.faint;
            
        }
        //get rid of output
        public override bool DependsOn(IGH_ActiveObject potential_source)
        {
            return base.DependsOn(potential_source);
        }



        //perform some simple action when the user clicks the button


        protected override System.Drawing.Bitmap Icon{get{return null;}}

        public override Guid ComponentGuid{get{return new Guid("5AB0F8A7-5F2F-408B-9FED-B2BD11E53728");}}
    }
}