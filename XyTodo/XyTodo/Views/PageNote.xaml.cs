using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XyTodo.Localizations;
using XyTodo.Models;

namespace XyTodo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageNote : ContentPage
    {
        public int ID { get; set; }
        public ModelTask model { get; set; }
        public Action<string> fnBack { get; set; }

        public PageNote(int id, Action<string> fn)
        {
            InitializeComponent();
            ID = id;
            fnBack = fn;
            BtnOK.Text = Localization.OK;
            InitPage();
        }

        async void InitPage()
        {
            model = await App.Database.GetItemAsync(ID);
            //绑定内容
            BindingContext = model;
        }

        async void BtnOK_Clicked(object sender, EventArgs e)
        {
            await App.Database.SaveItemAsync(model);
            await Navigation.PopAsync();
            fnBack(model.Note);
        }
    }
}