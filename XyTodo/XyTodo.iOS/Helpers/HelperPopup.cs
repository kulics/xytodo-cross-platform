using System;
using UIKit;
using Xamarin.Forms;
using XyTodo.Helpers;
using XyTodo.iOS.Helpers;

[assembly: Dependency(typeof(HelperPopup))]
namespace XyTodo.iOS.Helpers
{
    public class HelperPopup : IHelperPopup
    {
        public void DialogTextInput(string title, string placeholder, string ok, string cancel, Action<string> fn)
        {
            //创建对话框
            var alertController = UIAlertController.Create(title, "", UIAlertControllerStyle.Alert);
            //创建一个输入框
            alertController.AddTextField((textfiled) =>
            {
                textfiled.Placeholder = placeholder;
            });
            var btnOK = UIAlertAction.Create(ok, UIAlertActionStyle.Default, (action) =>
            {
                //判断数据不为空
                if (alertController.TextFields[0].Text.Length > 0)
                {
                    //响应方法
                    fn(alertController.TextFields[0].Text);
                }
            });
            var btnCancel = UIAlertAction.Create(cancel, UIAlertActionStyle.Cancel, null);
            alertController.AddAction(btnOK);
            alertController.AddAction(btnCancel);


            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);
        }
    }
}