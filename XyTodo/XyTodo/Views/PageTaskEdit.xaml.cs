using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XyTodo.Views
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class PageTaskEdit : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public PageTaskEdit()
        {
            InitializeComponent();

            Title = "Edit Task";

            //Items = new ObservableCollection<string>
            //{
            //    "Item 1",
            //    "Item 2",
            //    "Item 3",
            //    "Item 4",
            //    "Item 5"
            //};

            BindingContext = this;
        }

        async void Handle_ItemTapped( object sender, SelectedItemChangedEventArgs e )
        {
            if ( e.SelectedItem == null )
                return;

            await DisplayAlert( "Item Tapped", "An item was tapped.", "OK" );

            //Deselect Item
            ( (ListView) sender ).SelectedItem = null;
        }
    }
}