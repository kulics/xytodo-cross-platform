using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using XyTodo.Helpers;
using XyTodo.UWP.Helpers;

[assembly: Dependency(typeof(HelperPopup))]
namespace XyTodo.UWP.Helpers
{
    public class HelperPopup : IHelperPopup
    {
        public async void DialogTextInput(string title, string placeholder, string ok, string cancel, Action<string> fn)
        {
            //创建一个输入框
            var edtContent = new TextBox()
            {
                Margin = new Windows.UI.Xaml.Thickness(12, 20, 12, 8),
                PlaceholderText = placeholder
            };
            //创建对话框
            ContentDialog dialog = new ContentDialog()
            {
                Title = title,
                Content = edtContent,
                FullSizeDesired = false,
                PrimaryButtonText = ok,
                SecondaryButtonText = cancel
            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //判断数据不为空
                if (edtContent.Text.Length > 0)
                {
                    //响应方法
                    fn(edtContent.Text);
                }
            }
        }
    }
}
