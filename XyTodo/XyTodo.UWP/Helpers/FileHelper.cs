using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using XyTodo.Helpers;
using XyTodo.UWP.Helpers;

[assembly: Dependency(typeof(FileHelper))]
namespace XyTodo.UWP.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
