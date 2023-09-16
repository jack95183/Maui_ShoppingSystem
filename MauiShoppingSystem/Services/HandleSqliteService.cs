using MauiShoppingSystem.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiShoppingSystem.Services
{
    public class HandleSqliteService : IHandleSqliteService
    {
        //處理SQLite
        private SQLiteAsyncConnection _dbConnection;
        public HandleSqliteService()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            if(_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Config.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<SqliteConfigModel>();
            }
        }


        public Task<int> AddConfig(SqliteConfigModel SqliteConfigModel)
        {
            return _dbConnection.InsertAsync(SqliteConfigModel);
        }

        public Task<int> DeleteConfig(SqliteConfigModel SqliteConfigModel)
        {
            return _dbConnection.InsertAsync(SqliteConfigModel);
        }

        public async Task<List<SqliteConfigModel>> GetConfigList()
        {
            var ConfigList = await _dbConnection.Table<SqliteConfigModel>().ToListAsync();
            return ConfigList;
        }

        public Task<int> UpdateConfig(SqliteConfigModel SqliteConfigModel)
        {
            return _dbConnection.UpdateAsync(SqliteConfigModel);
        }
    }
}
