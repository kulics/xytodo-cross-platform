using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using XyTodo.Cross;
using XyTodo.UWP.Cross;

[assembly: Dependency(typeof(CrossFile))]
namespace XyTodo.UWP.Cross
{
    public class CrossFile : ICrossFile
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
        public string GetLocalImagePath(string imgname)
        {
            return "Images/" + imgname;
        }
    }
}
