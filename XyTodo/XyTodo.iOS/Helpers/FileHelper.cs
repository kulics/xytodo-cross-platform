using System;
using Xamarin.Forms;
using System.IO;
using XyTodo.iOS.Helpers;
using XyTodo.Helpers;

[assembly: Dependency(typeof(FileHelper))]
namespace XyTodo.iOS.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}