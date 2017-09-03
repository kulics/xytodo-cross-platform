using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XyTodo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRootMaster : ContentPage
    {
        public ListView ListView;

        public PageRootMaster()
        {
            InitializeComponent();

            BindingContext = new PageRootMasterViewModel();
            ListView = MenuItemsListView;
        }

        class PageRootMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PageRootMenuItem> MenuItems { get; set; }

            public PageRootMasterViewModel()
            {
                MenuItems = new ObservableCollection<PageRootMenuItem>(new[]
                {
                    new PageRootMenuItem { Id = 0, Title = "Home", TargetType = typeof(PageTaskList) },
                    new PageRootMenuItem { Id = 1, Title = "About", TargetType = typeof(PageAbout) },
                    new PageRootMenuItem { Id = 2, Title = "Guide", TargetType = typeof(PageGuide) },
                    new PageRootMenuItem { Id = 3, Title = "Contact Us", TargetType = typeof(PageContactUs) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}