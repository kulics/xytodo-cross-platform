using Foundation;
using Xamarin.Forms;
using XyTodo.Helpers;
using XyTodo.iOS.Helpers;

[assembly: Dependency( typeof( HelperUserPreferences ) )]
namespace XyTodo.iOS.Helpers
{
    class HelperUserPreferences : IHelperUserPreferences
    {
        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public string GetString( string key )
        {
            var rst = "";
            rst = NSUserDefaults.StandardUserDefaults.StringForKey( key );
            return rst;
        }

        public void PutString( string key, string value )
        {
            NSUserDefaults.StandardUserDefaults.SetString( value, key );
        }

        public int GetInt( string key )
        {
            var rst = 0;
            rst = (int) NSUserDefaults.StandardUserDefaults.IntForKey( key );
            return rst;
        }

        public void PutInt( string key, int value )
        {
            NSUserDefaults.StandardUserDefaults.SetInt( value, key );
        }
    }
}
