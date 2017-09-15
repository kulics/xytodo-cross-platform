using Xamarin.Forms;
using XyTodo.Cross;
using XyTodo.iOS.Cross;

[assembly: Dependency(typeof(CrossTheme))]
namespace XyTodo.iOS.Cross
{
    class CrossTheme : ICrossTheme
    {
        public void SetTheme(string color)
        {
        }
    }
}
