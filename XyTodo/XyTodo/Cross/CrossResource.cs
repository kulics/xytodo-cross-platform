using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XyTodo.Cross
{
    //标注扩展，用来访问PCL图片资源
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == Source)
                return null;
            return ImageSource.FromResource(Source);
        }
    }
}
