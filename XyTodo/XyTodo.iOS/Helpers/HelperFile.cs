using System;
using Xamarin.Forms;
using System.IO;
using XyTodo.iOS.Helpers;
using XyTodo.Helpers;

[assembly: Dependency( typeof( HelperFile ) )]
namespace XyTodo.iOS.Helpers
{
    public class HelperFile : IHelperFile
    {
        public string GetLocalFilePath( string filename )
        {
            string docFolder = Environment.GetFolderPath( Environment.SpecialFolder.Personal );
            string libFolder = Path.Combine( docFolder, "..", "Library", "Databases" );

            if ( !Directory.Exists( libFolder ) )
            {
                Directory.CreateDirectory( libFolder );
            }

            return Path.Combine( libFolder, filename );
        }
        public string GetLocalImagePath(string imgname)
        {
            return imgname;
        }
    }
}