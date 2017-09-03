using Android.Content;
using Xamarin.Forms;
using XyTodo.Droid.Helpers;
using XyTodo.Helpers;

[assembly: Dependency( typeof( HelperUserPreferences ) )]
namespace XyTodo.Droid.Helpers
{
    class HelperUserPreferences : IHelperUserPreferences
    {
        string fileName = "UserPreferences";

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public string GetString( string key )
        {
            var prefs = Android.App.Application.Context.GetSharedPreferences( fileName, FileCreationMode.Private );
            return prefs.GetString( key, "" );
        }

        public void PutString( string key, string value )
        {
            var prefs = Android.App.Application.Context.GetSharedPreferences( fileName, FileCreationMode.Private );
            var prefsEditor = prefs.Edit();

            prefsEditor.PutString( key, value );
            prefsEditor.Commit();
        }

        public int GetInt( string key )
        {
            var prefs = Android.App.Application.Context.GetSharedPreferences( fileName, FileCreationMode.Private );
            return prefs.GetInt( key, 0 );
        }

        public void PutInt( string key, int value )
        {
            var prefs = Android.App.Application.Context.GetSharedPreferences( fileName, FileCreationMode.Private );
            var prefsEditor = prefs.Edit();

            prefsEditor.PutInt( key, value );
            prefsEditor.Commit();
        }
    }
}