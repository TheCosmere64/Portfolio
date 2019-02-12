using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AIMS.Core.Helpers;
using Foundation;
using UIKit;

namespace AIMS.iOS
{
    public class FileHelperIOS : IFileHelper
    {
        public string GetLocalPath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Database");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }
    }
}