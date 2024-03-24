using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.ToolBox
{
    internal  class ReportFilesInFolder
    {

        String filePath = null;
        bool trigger = false;
        List<string> FileNames = new List<string>();
        public  List<string> GetFilePaths(string inputFilePath, bool inputTrigger)
        {
            filePath = inputFilePath;
            trigger = inputTrigger;

            if (trigger && Directory.Exists(filePath))
            {
                foreach (string file in Directory.GetFiles(filePath))
                {
                    //only get.gh files and 
                    if (file.Contains(".gh"))
                    {
                        Uri baseUri = new Uri(file);
                        //GetRelitivePath
                        Uri relitiveUri = baseUri.MakeRelativeUri(new Uri(filePath));
                        //FileNames.Add(relitiveUri.ToString() + @"/" + Path.GetFileName(file));

                        FileNames.Add($"{relitiveUri}//{Path.GetFileName(file)}");
                        
                    }
                }
                // fileNames.Add(Directory.GetFiles(filePath).ToString());
            }  

            return FileNames;

        }
    }
}
