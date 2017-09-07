using Android.Content;
using System;
using Xamarin.Forms;
using XyTodo.Cross;
using XyTodo.Droid.Cross;

[assembly: Dependency(typeof(CrossFunction))]
namespace XyTodo.Droid.Cross
{
    class CrossFunction : ICrossFunction
    {
        public string GetClipbroad()
        {
            //获取剪切板内容
            var cmb = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            var clip = "";
            // 检查剪贴板是否有内容
            if (cmb.HasPrimaryClip)
            {
                var data = cmb.PrimaryClip;
                var item = data.GetItemAt(0);

                clip = item.Text;
            }
            return clip;
        }

        public void SetClipbroad(string content)
        {
            //复制数据至剪切板
            var cd = ClipData.NewPlainText("label", content);
            var cmb = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            cmb.PrimaryClip = cd;
        }

        public void ShareString(string title, string content)
        {
            //创建意图
            var intent = new Intent(Intent.ActionSend);
            //装填数据
            intent.PutExtra(Intent.ExtraText, content);
            intent.SetType("text/*");
            //启动服务
            Forms.Context.StartActivity(intent);
        }
    }
}