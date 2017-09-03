using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XyTodo.ViewModels;

namespace XyTodo.Views
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class PageTaskList : ContentPage
    {
        public ObservableCollection<ViewModelTask> Items { get; set; }

        public PageTaskList()
        {
            InitializeComponent();
            //创建内存
            Items = new ObservableCollection<ViewModelTask>();
            //获取数据库数据
            var arr = App.Database.GetItemsAsync();
            //装载到UI
            foreach ( var model in arr.Result )
            {
                Items.Add( new ViewModelTask() { ID = model.ID, Content = model.Content } );
            }
            //绑定内容
            BindingContext = this;

        }

        async void Handle_ItemTapped( object sender, SelectedItemChangedEventArgs e )
        {
            if ( e.SelectedItem == null ) { return; }

            //弹出框
            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            await Navigation.PushAsync( new PageTaskEdit() );

            //Deselect Item
            ( (ListView) sender ).SelectedItem = null;
        }

        private void BtnAdd_Clicked( object sender, System.EventArgs e )
        {
            var modelNew = new Models.ModelTask() { Content = "new" };
            App.Database.SaveItemAsync( modelNew );
            Items.Add( new ViewModelTask() { ID = modelNew.ID, Content = modelNew.Content } );
        }
    }
}