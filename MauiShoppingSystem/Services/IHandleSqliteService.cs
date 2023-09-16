using MauiShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiShoppingSystem.Services
{
    public interface IHandleSqliteService
    {
        Task<List<SqliteConfigModel>> GetConfigList();
        Task<int> AddConfig(SqliteConfigModel SqliteConfigModel);
        Task<int> DeleteConfig(SqliteConfigModel SqliteConfigModel);
        Task<int> UpdateConfig(SqliteConfigModel SqliteConfigModel);

    }
}
