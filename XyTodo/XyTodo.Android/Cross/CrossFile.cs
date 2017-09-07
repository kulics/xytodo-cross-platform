using System.IO;
using Xamarin.Forms;
using System;
using XyTodo.Droid.Cross;
using XyTodo.Cross;

[assembly: Dependency(typeof(CrossFile))]
namespace XyTodo.Droid.Cross
{
    public class CrossFile : ICrossFile
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
        public string GetLocalImagePath(string imgname)
        {
            return imgname;
        }
    }
}