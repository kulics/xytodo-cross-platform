using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XyTodo.Models;

namespace XyTodo.Databases
{
    public class DBManager
    {
        readonly SQLiteAsyncConnection database;

        public DBManager(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ModelTask>().Wait();
        }

        public Task<List<ModelTask>> GetItemsAsync()
        {
            return database.Table<ModelTask>().ToListAsync();
        }

        public Task<List<ModelTask>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<ModelTask>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<ModelTask> GetItemAsync(int id)
        {
            return database.Table<ModelTask>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ModelTask item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ModelTask item)
        {
            return database.DeleteAsync(item);
        }
    }
}
