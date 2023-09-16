using Dapper;
using MauiShoppingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiShoppingSystem.Services
{
    public interface ISqlServerDataAccessService
    {
        public ResultModel<List<UserModel>> QueryAllUser();
        public ResultModel<List<UserModel>> InsertNewUser(SqlUserModel UserModel);
        public ResultModel<List<CommodityModel>> QueryAllCommodity();
        public ResultModel<List<ShoppingCartJoinCommodityModel>> QueryUserShoppingCart(string userid);
        public ResultModel<List<ShoppingCartJoinCommodityModel>> AddUpdateUserShoppingCart(string userid, string type, ShoppingCartJoinCommodityModel ShoppingCartJoinCommodityModel);

    }
}
