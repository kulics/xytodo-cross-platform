using System;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using XyTodo.Cross;
using XyTodo.UWP.Cross;

[assembly: Dependency(typeof(CrossPopup))]
namespace XyTodo.UWP.Cross
{
    public class CrossPopup : ICrossPopup
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
