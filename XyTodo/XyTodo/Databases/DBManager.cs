﻿using System.Collections.Generic;
using System.Threading.Tasks;
using XyTodo.Models;

namespace XyTodo.Databases
{
    //数据库操作方法
    public class DBManager
    {
        //数据库帮助
        public DBHelper helper;
        //构造方法
        public DBManager( string dbPath )
        {
            helper = new DBHelper( dbPath );
        }

        public Task<List<ModelTask>> GetItemsAsync()
        {
            return helper.GetConnection().Table<ModelTask>().ToListAsync();
        }

        public Task<List<ModelTask>> GetItemsNotDoneAsync()
        {
            return helper.GetConnection().QueryAsync<ModelTask>( "SELECT * FROM [TodoItem] WHERE [Done] = 0" );
        }

        public Task<ModelTask> GetItemAsync( int id )
        {
            return helper.GetConnection().Table<ModelTask>().Where( i => i.ID == id ).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync( ModelTask item )
        {
            if ( item.ID != 0 )
            {
                return helper.GetConnection().UpdateAsync( item );
            }
            else
            {
                return helper.GetConnection().InsertAsync( item );
            }
        }

        public Task<int> DeleteItemAsync( ModelTask item )
        {
            return helper.GetConnection().DeleteAsync( item );
        }
    }
}
