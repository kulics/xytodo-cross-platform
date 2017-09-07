using Foundation;
using Xamarin.Forms;
using XyTodo.Cross;
using XyTodo.iOS.Cross;

[assembly: Dependency( typeof( CrossUserPreferences ) )]
namespace XyTodo.iOS.Cross
{
    class CrossUserPreferences : ICrossUserPreferences
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
