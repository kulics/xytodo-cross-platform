namespace XyTodo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new XyTodo.App());
        }
    }
}