using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.ToolBox
{
    public class FileWatcher
    {
        private FileSystemWatcher watcher;
        private string filePath;
        public bool FileSaved { get; private set; }

        public void FileSaveWatcher(string path)
        {
            filePath = path;
            FileSaved = false;

            // Initialize the watcher
            watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName(filePath);
            watcher.Filter = Path.GetFileName(filePath);
            watcher.NotifyFilter = NotifyFilters.LastWrite; // Watch for changes in LastWrite times

            // Add event handlers
            watcher.Changed += OnChanged;

            // Begin watching
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Set the FileSaved flag or perform other actions
            FileSaved = true;

            // Optionally, disable further events if you only need to know about the first save
            // watcher.EnableRaisingEvents = false;
        }

        // Call this method to reset the FileSaved flag
        public void ResetFlag()
        {
            FileSaved = false;
        }
    }
}
