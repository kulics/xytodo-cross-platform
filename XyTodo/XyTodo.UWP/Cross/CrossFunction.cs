using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Xamarin.Forms;
using XyTodo.Cross;
using XyTodo.UWP.Cross;

[assembly: Dependency(typeof(CrossFunction))]
namespace XyTodo.UWP.Cross
{
    class CrossFunction : ICrossFunction
    {
        string title;
        string content;

        public string GetClipbroad()
        {
            return getClipbroadString().Result;
        }
        //获取剪切板内容
        private async Task<string> getClipbroadString()
        {
            //获取剪切板数据
            DataPackageView pv = Clipboard.GetContent();
            var clip = "";
            //判断是否文本
            if (pv.Contains(StandardDataFormats.Text))
            {
                clip = await Clipboard.GetContent().GetTextAsync();
            }
            return clip;
        }

        public void SetClipbroad(string content)
        {
            //复制数据至剪切板
            DataPackage dp = new DataPackage();
            dp.SetText(content);
            Clipboard.SetContent(dp);
        }

        public void ShareString(string title, string content)
        {
            //将内容放入中间变量
            this.title = title;
            this.content = content;

            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataRequested;

            DataTransferManager.ShowShareUI();
        }

        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = title;
            //request.Data.Properties.Description = "An example of how to share text.";
            //复制数据至剪切板
            string str = content;
            request.Data.SetText(str);
        }
    }
}
