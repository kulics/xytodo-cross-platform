using System.IO;
using Xamarin.Forms;
using System;
using XyTodo.Droid.Helpers;
using XyTodo.Helpers;

[assembly: Dependency(typeof(FileHelper))]
namespace XyTodo.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}