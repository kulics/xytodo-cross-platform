﻿using Windows.Storage;
using Xamarin.Forms;
using XyTodo.Helpers;
using XyTodo.UWP.Helpers;

[assembly: Dependency( typeof( HelperUserPreferences ) )]
namespace XyTodo.UWP.Helpers
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
            if ( ApplicationData.Current.LocalSettings.Values.ContainsKey( key ) )
            {
                rst = (string) ApplicationData.Current.LocalSettings.Values[key];
            }
            return rst;
        }

        public void PutString( string key, string value )
        {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }

        public int GetInt( string key )
        {
            var rst = 0;
            if ( ApplicationData.Current.LocalSettings.Values.ContainsKey( key ) )
            {
                rst = (int) ApplicationData.Current.LocalSettings.Values[key];
            }
            return rst;
        }

        public void PutInt( string key, int value )
        {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }
    }
}
