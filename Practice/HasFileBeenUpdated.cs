using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Practice.ToolBox;

namespace Practice
{
    public class HasFileBeenUpdated : GH_Component
    {

        public HasFileBeenUpdated()
          : base(
                "HasFileBeenUpdated",
                "Nickname",
                "Description",
                "ZZ",
                "Z"
                )
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Path", "P", "Path", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Updated", "U", "Updated", GH_ParamAccess.item);
            pManager.AddTextParameter("Path", "P", "Path", GH_ParamAccess.item);
        }

        protected string FileUpdated(string path)
        {
            var file = new System.IO.FileInfo(path);
            var now = DateTime.Now;
            var lastWriteTime = file.LastWriteTime;
            var lastWriteTimeUTC = file.LastWriteTimeUtc;
            var lastAccessTime = file.LastAccessTime;
            var lastAccessTimeUTC = file.LastAccessTimeUtc;
            var creationTime = file.CreationTime;
            var creationTimeUTC = file.CreationTimeUtc;
            
            var nowUTC = DateTime.UtcNow;
            var timeSinceLastWrite = now - lastWriteTime;
            var timeSinceLastWriteUTC = nowUTC - lastWriteTimeUTC;
            var timeSinceLastAccess = now - lastAccessTime;
            var timeSinceLastAccessUTC = nowUTC - lastAccessTimeUTC;
            var timeSinceCreation = now - creationTime;
            var timeSinceCreationUTC = nowUTC - creationTimeUTC;
            var timeSinceLastWriteInSeconds = timeSinceLastWrite.TotalSeconds;
            var timeSinceLastWriteUTCInSeconds = timeSinceLastWriteUTC.TotalSeconds;
            var timeSinceLastAccessInSeconds = timeSinceLastAccess.TotalSeconds;
            var timeSinceLastAccessUTCInSeconds = timeSinceLastAccessUTC.TotalSeconds;
            var timeSinceCreationInSeconds = timeSinceCreation.TotalSeconds;
            var timeSinceCreationUTCInSeconds = timeSinceCreationUTC.TotalSeconds;
            var timeSinceLastWriteInMinutes = timeSinceLastWrite.TotalMinutes;
            var timeSinceLastWriteUTCInMinutes = timeSinceLastWriteUTC.TotalMinutes;
            var timeSinceLastAccessInMinutes = timeSinceLastAccess.TotalMinutes;
            var timeSinceLastAccessUTCInMinutes = timeSinceLastAccessUTC.TotalMinutes;
            var timeSinceCreationInMinutes = timeSinceCreation.TotalMinutes;
            var timeSinceCreationUTCInMinutes = timeSinceCreationUTC.TotalMinutes;
            var timeSinceLastWriteInHours = timeSinceLastWrite.TotalHours;
            var timeSinceLastWriteUTCInHours = timeSinceLastWriteUTC.TotalHours;
            var timeSinceLastAccessInHours = timeSinceLastAccess.TotalHours;
            var timeSinceLastAccessUTCInHours = timeSinceLastAccessUTC.TotalHours;
            var timeSinceCreationInHours = timeSinceCreation.TotalHours;
            var timeSinceCreationUTCInHours = timeSinceCreationUTC.TotalHours;
            var timeSinceLastWriteInDays = timeSinceLastWrite.TotalDays;
            //var timeSinceLastWriteUTC;
            return lastWriteTime.ToString();
        }


        protected override void SolveInstance(IGH_DataAccess DA)
        {
            FileWatcher watcher = new FileWatcher();
            //filewa
            
            bool ted = watcher.FileSaved;
                
            string path = null;
            DA.GetData(0, ref path);
            //var updated = FileUpdated(path);
            DA.SetData(0, FileUpdated(path));
            
        }



        protected override System.Drawing.Bitmap Icon { get { return null; } }
        public override Guid ComponentGuid { get { return new Guid("82BA2651-6494-450C-B00A-17E64C359694"); } }
    }
}