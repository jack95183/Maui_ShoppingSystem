using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiShoppingSystem.Models
{
    
    public class SqliteConfigModel
    {
        [PrimaryKey]
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
