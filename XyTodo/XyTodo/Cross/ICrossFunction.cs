namespace XyTodo.Cross
{
    public interface ICrossFunction
    {
        string GetClipbroad();
        void SetClipbroad(string content);
        void ShareString(string title, string content);
    }
}
