using Xamarin.Forms;
using XyTodo.ViewModels;

namespace XyTodo.Components
{
    //任务编辑的视图选择器
    class DataTemplateSelectorTaskEdit : DataTemplateSelector
    {
        public DataTemplate TemplateHead { get; set; }
        public DataTemplate TemplateTime { get; set; }
        public DataTemplate TemplateNote { get; set; }
        public DataTemplate TemplateSub { get; set; }
        //选择方法
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch ((item as ViewModelTaskEdit).Type)
            {
                case "head":
                    return TemplateHead;
                case "time":
                    return TemplateTime;
                case "note":
                    return TemplateNote;
                case "sub":
                    return TemplateSub;
                default:
                    return TemplateSub;
            }
        }
    }
}
