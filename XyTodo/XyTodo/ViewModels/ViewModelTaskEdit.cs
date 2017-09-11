using System.ComponentModel;

namespace XyTodo.ViewModels
{
    //引入属性更新接口
    public class ViewModelTaskEdit : ViewModelBase, INotifyPropertyChanged
    {
        public int ID { get; set; }
        string content;
        public string Content
        {
            set
            {
                if(content != value)
                {
                    content = value;
                    //设置更新通知
                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Content"));
                    }
                }
            }
            get { return content; }
        }
        public int Status { get; set; }
        public string Type { get; set; }

        public string ResPlaceholder { get; set; }
        public string ResButton { get; set; }

        public ViewModelTaskEdit()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
