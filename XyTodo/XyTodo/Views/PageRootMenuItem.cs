using System;

namespace XyTodo.Views
{

    public class PageRootMenuItem
    {
        public PageRootMenuItem() { }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}