using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using XyTodo.Helpers;
using XyTodo.UWP.Helpers;

[assembly: Dependency(typeof(HelperFile))]
namespace XyTodo.UWP.Helpers
{
    public class HelperFile : IHelperFile
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
