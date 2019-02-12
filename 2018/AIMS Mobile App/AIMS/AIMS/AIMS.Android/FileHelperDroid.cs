#region

using AIMS.Core.Helpers;

#endregion

namespace AIMS.Droid
{
    public class FileHelperDroid : IFileHelper
    {
        public string GetLocalPath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
    }
}