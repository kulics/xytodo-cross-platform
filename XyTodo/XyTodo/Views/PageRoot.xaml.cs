using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XyTodo.Cross;
using XyTodo.Localizations;

namespace XyTodo.Views
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class PageRoot : MasterDetailPage
    {
        //主页
        PageTaskList pHome;
        //构造方法
        public PageRoot()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            //设置主题
            DependencyService.Get<ICrossTheme>().SetTheme("black");

            //初始化各个页面
            pHome = new PageTaskList();
            pHome.Title = Localization.Home;
            //将当前页设置为主页
            Detail = new NavigationPage( pHome );
        }

        private void ListView_ItemSelected( object sender, SelectedItemChangedEventArgs e )
        {
            //获取选择的菜单项
            var item = e.SelectedItem as PageRootMenuItem;
            //异常处理
            if ( item == null ) { return; }

            Page page;
            //根据选项切换页面
            switch ( item.Id )
            {
                case 0:
                    page = pHome;
                    break;
                default:
                    page = (Page) Activator.CreateInstance( item.TargetType );
                    break;
            }
            page.Title = item.Title;

            Detail = new NavigationPage( page );
            //手动关闭菜单页
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}