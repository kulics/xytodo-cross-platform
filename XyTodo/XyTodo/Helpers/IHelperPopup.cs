using System;

namespace XyTodo.Helpers
{
    public delegate void ClickMethod();

    public interface IHelperPopup
    {
        //带输入框弹窗
        void DialogTextInput(string title, string placeholder, string ok, string cancel, Action<string> fn);
    }
}
