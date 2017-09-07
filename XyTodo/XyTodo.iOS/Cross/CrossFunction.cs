using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XyTodo.iOS.Cross;
using XyTodo.Cross;

[assembly: Dependency(typeof(CrossFunction))]
namespace XyTodo.iOS.Cross
{
    class CrossFunction : ICrossFunction
    {
        public string GetClipbroad()
        {
            //获取剪切板内容
            var clip = "";
            // 检查剪贴板是否有内容
            if (UIPasteboard.General.String != null)
            {
                clip = UIPasteboard.General.String;
            }
            return clip;
        }

        public void SetClipbroad(string content)
        {
            //复制数据至剪切板
            var pb = UIPasteboard.General;
            pb.String = content;
        }

        public void ShareString(string title, string content)
        {
            //一个URL
            //let shareURL = NSURL(string: "http://www.baidu.com")
            //初始化一个UIActivity
            var activity = new UIActivity();

            NSString[] activityItems = { new NSString(content) };
            UIActivity[] activities = { activity };
            //初始化UIActivityViewController
            var activityController = new UIActivityViewController(activityItems, activities);
            //排除一些服务：例如复制到粘贴板，拷贝到通讯录
            //activityController.excludedActivityTypes = [UIActivityTypeCopyToPasteboard,UIActivityTypeAssignToContact]
            //为ipad增加挂靠设置
            //activityController.popoverPresentationController?.barButtonItem = mActionButton
            var parent = UIApplication.SharedApplication.KeyWindow.RootViewController;
            activityController.PopoverPresentationController.SourceView = parent.View;
            activityController.PopoverPresentationController.SourceRect = parent.View.Bounds;
            //弹出控制器
            parent.PresentViewController(activityController, true, null);
        }
    }
}