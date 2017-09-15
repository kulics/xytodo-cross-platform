using Xamarin.Forms;
using XyTodo.Cross;
using XyTodo.Droid.Cross;
using Android.App;
using XyTodo.Helpers;

[assembly: Dependency(typeof(CrossTheme))]
namespace XyTodo.Droid.Cross
{
    public class CrossTheme : ICrossTheme
    {
        Android.Graphics.Color dark;

        public void SetTheme(string color)
        {
            //获取颜色值
            GetThemeColor(color);
            //设置状态栏颜色
            var activity = (Activity)Forms.Context;
            var window = activity.Window;
            window.SetStatusBarColor(dark);
        }

        Android.Graphics.Color GetColor(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            
            byte r = (byte)(int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber));
            byte g = (byte)(int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber));
            byte b = (byte)(int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
            var myColor = new Android.Graphics.Color(r, g, b);
            return myColor;
        }

        void GetThemeColor(string color)
        {
            var hex = "";
            switch(color)
            {
                case "black":
                    hex = HelperColor.Black700;
                    break;
                case "green":
                    hex = HelperColor.Green700;
                    break;
                case "red":
                    hex = HelperColor.Red700;
                    break;
                case "blue":
                    hex = HelperColor.Blue700;
                    break;
                case "cyan":
                    hex = HelperColor.Cyan700;
                    break;
                case "yellow":
                    hex = HelperColor.Yellow700;
                    break;
                case "indigo":
                    hex = HelperColor.Indigo700;
                    break;
                case "purple":
                    hex = HelperColor.Purple700;
                    break;
                case "pink":
                    hex = HelperColor.Pink700;
                    break;
            }
            dark = GetColor(hex);
        }
    }
}