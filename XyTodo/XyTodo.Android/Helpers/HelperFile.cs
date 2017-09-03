using System.IO;
using Xamarin.Forms;
using System;
using XyTodo.Droid.Helpers;
using XyTodo.Helpers;

[assembly: Dependency(typeof(HelperFile))]
namespace XyTodo.Droid.Helpers
{
    public class HelperFile : IHelperFile
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}