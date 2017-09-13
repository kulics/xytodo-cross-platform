using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XyTodo.Localizations;
using XyTodo.Models;
using XyTodo.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Json;

namespace XyTodo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTaskEdit : ContentPage
    {
        public ObservableCollection<ViewModelTaskEdit> Items { get; set; }
        string resDelete = Localization.Delete;
        string resContent = Localization.Content;
        public int ID { get; set; }
        ModelTask dataset;

        public PageTaskEdit(int id)
        {
            InitializeComponent();
            ID = id;

            Title = "Edit Task";
            BtnOK.Text = Localization.OK;

            InitPage();
            BindingContext = this;
        }

        async void InitPage()
        {
            dataset = await App.Database.GetItemAsync(ID);

            var vm = new ViewModelTask().FromModel(dataset);

            Items = new ObservableCollection<ViewModelTaskEdit>
            {
                new ViewModelTaskEdit{ ID = 0, Content = vm.Content, Type = "head", ResPlaceholder = resContent, ResButton = resDelete },
                new ViewModelTaskEdit{ ID = 1, Content = vm.TimeTarget.ToString(), Type = "time", ResPlaceholder = resContent, ResButton = resDelete},
                new ViewModelTaskEdit{ ID = 2, Content = vm.Note, Type = "note", ResPlaceholder = resContent, ResButton = resDelete},
                new ViewModelTaskEdit{ ID = 3, Content = "111", Type = "sub", ResPlaceholder = resContent, ResButton = resDelete }
            };
            listview.ItemsSource = Items;
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }
            //监听备注
            if ((e.SelectedItem as ViewModelTaskEdit).ID == 2)
            {
                //弹出备注编辑页面，并指定返回方法
                await Navigation.PushAsync(new PageNote(ID, (note) =>
                {
                    //更新本页面内容
                    Items[2].Content = note;
                }));
            }
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void BtnOK_Clicked(object sender, EventArgs e)
        {
        }

        private async void NetEvent()
        {
            //创建参数
            var pdata = new JsonObject
            {
                { "account", "test@test.com" },
                { "password", "12345678" }
            };

            //创建url
            string uri = "https://test.test/";

            //装载参数
            var dic = new Dictionary<string, string>();
            dic.Add("params", pdata.ToString());

            //创建请求
            var content = new FormUrlEncodedContent(dic);
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.PostAsync(uri, content);
                //读取返回结果
                var k = await response.Content.ReadAsStringAsync();
                //解析数据
                var result = JsonObject.Parse(k);
            }
            catch(Exception err)
            {
                Debug.WriteLineIf(true, err.ToString());
            }
        }
    }
}