using System;

namespace XyTodo.Cross
{
    public interface ICrossPopup
    {
        //带输入框弹窗
        void DialogTextInput(string title, string placeholder, string ok, string cancel, Action<string> fn);
    }
}
