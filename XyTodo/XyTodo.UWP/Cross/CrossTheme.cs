using System;
using Windows.UI;
using Windows.UI.ViewManagement;
using Xamarin.Forms;
using XyTodo.Cross;
using XyTodo.UWP.Cross;
using XyTodo.Helpers;

[assembly: Dependency(typeof(CrossTheme))]
namespace XyTodo.UWP.Cross
{
    public class CrossTheme : ICrossTheme
    {
        Windows.UI.Color normal;
        Windows.UI.Color light;
        Windows.UI.Color light2;

        public void SetTheme(string color)
        {
            //获取颜色值
            GetThemeColor(color);
            //获取标题栏
            var appTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            //设置标题栏属性
            appTitleBar.ForegroundColor = Colors.White;
            appTitleBar.BackgroundColor = normal;
            appTitleBar.ButtonBackgroundColor = normal;
            appTitleBar.ButtonHoverBackgroundColor = light;
            appTitleBar.ButtonForegroundColor = Colors.White;
            appTitleBar.ButtonPressedBackgroundColor = light2;
            appTitleBar.ButtonPressedForegroundColor = Colors.White;
            //windows phone
            if(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var statusBar = StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = normal;
                statusBar.ForegroundColor = Colors.White;
                statusBar.BackgroundOpacity = 1;
            }
        }
        Windows.UI.Color GetColor(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte r = (byte)(int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber));
            byte g = (byte)(int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber));
            byte b = (byte)(int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
            var myColor = Windows.UI.Color.FromArgb(0xff, r, g, b);
            return myColor;
        }

        void GetThemeColor(string color)
        {
            var hexNormal = "";
            var hexLight = "";
            switch(color)
            {
                case "black":
                    hexNormal = HelperColor.Black500;
                    hexLight = HelperColor.Black300;
                    break;
                case "green":
                    hexNormal = HelperColor.Green500;
                    hexLight = HelperColor.Green300;
                    break;
                case "red":
                    hexNormal = HelperColor.Red500;
                    hexLight = HelperColor.Red300;
                    break;
                case "blue":
                    hexNormal = HelperColor.Blue500;
                    hexLight = HelperColor.Blue300;
                    break;
                case "cyan":
                    hexNormal = HelperColor.Cyan500;
                    hexLight = HelperColor.Cyan300;
                    break;
                case "yellow":
                    hexNormal = HelperColor.Yellow500;
                    hexLight = HelperColor.Yellow300;
                    break;
                case "indigo":
                    hexNormal = HelperColor.Indigo500;
                    hexLight = HelperColor.Indigo300;
                    break;
                case "purple":
                    hexNormal = HelperColor.Purple500;
                    hexLight = HelperColor.Purple300;
                    break;
                case "pink":
                    hexNormal = HelperColor.Pink500;
                    hexLight = HelperColor.Pink300;
                    break;
            }
            normal = GetColor(hexNormal);
            light = GetColor(hexLight);
            light2 = GetColor(HelperColor.Yellow300);
        }

    }
}
