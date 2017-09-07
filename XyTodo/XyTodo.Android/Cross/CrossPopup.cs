using Android.App;
using Android.Widget;
using System;
using Xamarin.Forms;
using XyTodo.Droid.Cross;
using XyTodo.Cross;

[assembly: Dependency(typeof(CrossPopup))]
namespace XyTodo.Droid.Cross
{
    public class CrossPopup : ICrossPopup
    {
        public void DialogTextInput(string title, string placeholder, string ok, string cancel, Action<string> fn)
        {
            //创建一个输入框
            var edtContent = new EditText((Activity)Forms.Context);
            edtContent.Hint = placeholder;
            //还未改动间距
            //创建对话框
             new AlertDialog.Builder((Activity)Forms.Context).SetTitle(title)
            .SetView(edtContent)
            .SetPositiveButton(ok, (dialog, id) => 
            {
                //判断数据不为空
                if (edtContent.Text.Length > 0)
                {
                    //响应方法
                    fn(edtContent.Text);
                }
            })
            .SetNegativeButton(cancel, (dialog, id) => 
            {
            })
            .Show();
        }
    }
}