using System;
using System.Collections.Generic;
using System.Text;

namespace XyTodo.ViewModels
{
    public class ViewModelTask : ViewModelBase
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public int TimeCreate { get; set; }
        public int TimeTarget { get; set; }
        public int TimeDone { get; set; }
        public int TimeSort { get; set; }
        public int Status { get; set; }
        public int Sub { get; set; }

        public ViewModelTask() { }
    }
}
