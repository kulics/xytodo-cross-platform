using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XyTodo.Localizations;

namespace XyTodo.Views
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class PageRootMaster : ContentPage
    {
        public ListView ListView;
        public string AppName;

        public PageRootMaster()
        {
            InitializeComponent();

            BindingContext = new PageRootMasterViewModel();
            ListView = MenuItemsListView;
            MenuLabel.Text = Localization.AppName;
            Title = Localization.Menu;
        }

        class PageRootMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PageRootMenuItem> MenuItems { get; set; }

            public PageRootMasterViewModel()
            {
                MenuItems = new ObservableCollection<PageRootMenuItem>( new[]
                {
                    new PageRootMenuItem { Id = 0, Title = Localization.Home, TargetType = typeof(PageTaskList) },
                    new PageRootMenuItem { Id = 1, Title = Localization.About, TargetType = typeof(PageAbout) },
                    new PageRootMenuItem { Id = 2, Title = Localization.Guide, TargetType = typeof(PageGuide) },
                    new PageRootMenuItem { Id = 3, Title = Localization.ContactUs, TargetType = typeof(PageContactUs) },
                } );
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged( [CallerMemberName] string propertyName = "" )
            {
                if ( PropertyChanged == null )
                    return;

                PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
            }
            #endregion
        }
    }
}