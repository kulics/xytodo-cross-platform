using SQLite;
using XyTodo.Models;

namespace XyTodo.Databases
{
    //数据库帮助
    public class DBHelper
    {
        readonly SQLiteAsyncConnection connAsync;
        //readonly SQLiteConnection connSync;
        //数据库文件名称
        public const string DATABASE_NAME = "SQLite.db3";
        //数据库版本号
        public const int DATABASE_VERSION = 1;

        //构造函数，在这里检查数据库情况并检查
        public DBHelper(string dbPath)
        {
            connAsync = new SQLiteAsyncConnection(dbPath);
            //connSync = new SQLiteConnection(dbPath);
            var value = DATABASE_VERSION;
            //判断是否存在
            if(App.UserPreferences.GetInt("db_version") != 0)
            {
                //有则读取
                value = App.UserPreferences.GetInt("db_version");
                OnUpgrade(value, DATABASE_VERSION);
            }
            else
            {
                //没有则创建
                OnCreate();
                App.UserPreferences.PutInt("db_version", DATABASE_VERSION);
            }
        }
        //获取单个异步链接并返回
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            // 连接数据库，如果数据库文件不存在则创建一个空数据库。
            //var conn = new SQLiteConnection(DATABASE_NAME);
            //var conn = new SQLiteConnection(new SQLitePlatformWinRT(), DataBasePath);
            // 创建 Person 模型对应的表，如果已存在，则忽略该操作。
            //conn.CreateTable<Person>();
            return connAsync;
        }
        //获取单个同步链接并返回
        //public SQLiteConnection GetSyncConnection()
        //{
        //    return connSync;
        //}


        //创建数据库
        private void OnCreate()
        {
            connAsync.CreateTableAsync<ModelTask>().Wait();
            connAsync.CreateTableAsync<ModelTaskSub>().Wait();
        }
        //更新数据库
        private void OnUpgrade(int oldVersion, int newVersion)
        {
            var upgradeVersion = oldVersion;
            //依次迭代版本
            //if ( 1 == upgradeVersion )
            //{
            //    //添加表
            //    //执行语句
            //    var result = connection.ExecuteAsync( "CREATE TABLE IF NOT EXISTS safe ( safe_id INTEGER PRIMARY KEY, question TEXT, result TEXT );" );
            //    upgradeVersion = 2;
            //}
            if(upgradeVersion != newVersion)
            {
            }
            App.UserPreferences.PutInt("db_version", upgradeVersion);
        }
    }
}
