using XyTodo.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XyTodo.Databases;
using XyTodo.Helpers;

[assembly: XamlCompilation( XamlCompilationOptions.Compile )]
namespace XyTodo
{
    public partial class App : Application
    {
        //数据库
        static DBManager database;
        //用户设置
        static IHelperUserPreferences userPreferences;


        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new PageRoot();
        }

        public static DBManager Database
        {
            get
            {
                if ( database == null )
                {
                    database = new DBManager( DependencyService.Get<IHelperFile>().GetLocalFilePath( DBHelper.DATABASE_NAME ) );
                }
                return database;
            }
        }

        public static IHelperUserPreferences UserPreferences
        {
            get
            {
                if ( userPreferences == null )
                {
                    userPreferences = DependencyService.Get<IHelperUserPreferences>();
                }
                return userPreferences;
            }
        }

        //public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            //Debug.WriteLine("OnStart");

            //// always re-set when the app starts
            //// users expect this (usually)
            ////			Properties ["ResumeAtTodoId"] = "";
            //if (Properties.ContainsKey("ResumeAtTodoId"))
            //{
            //	var rati = Properties["ResumeAtTodoId"].ToString();
            //	Debug.WriteLine("   rati=" + rati);
            //	if (!String.IsNullOrEmpty(rati))
            //	{
            //		Debug.WriteLine("   rati=" + rati);
            //		ResumeAtTodoId = int.Parse(rati);

            //		if (ResumeAtTodoId >= 0)
            //		{
            //			var todoPage = new TodoItemPage();
            //			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
            //			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
            //		}
            //	}
            //}
        }

        protected override void OnSleep()
        {
            //Debug.WriteLine("OnSleep saving ResumeAtTodoId = " + ResumeAtTodoId);
            //// the app should keep updating this value, to
            //// keep the "state" in case of a sleep/resume
            //Properties["ResumeAtTodoId"] = ResumeAtTodoId;
        }

        protected override void OnResume()
        {
            //Debug.WriteLine("OnResume");
            //if (Properties.ContainsKey("ResumeAtTodoId"))
            //{
            //	var rati = Properties["ResumeAtTodoId"].ToString();
            //	Debug.WriteLine("   rati=" + rati);
            //	if (!String.IsNullOrEmpty(rati))
            //	{
            //		Debug.WriteLine("   rati=" + rati);
            //		ResumeAtTodoId = int.Parse(rati);

            //		if (ResumeAtTodoId >= 0)
            //		{
            //			var todoPage = new TodoItemPage();
            //			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
            //			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
            //		}
            //	}
            //}
        }

    }
}
