using Dapper;
using MauiShoppingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;


namespace MauiShoppingSystem.Services
{
    public class SqlServerDataAccessService : ISqlServerDataAccessService
    {
        public ResultModel<List<UserModel>> QueryAllUser()
        {
            ResultModel<List<UserModel>> result = new ResultModel<List<UserModel>>();
            try
            {
                using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-M66CUPJ;Initial Catalog=mydb; Persist Security Info=True;User ID=jack;Password=123456;Connect Timeout=60;Max Pool Size=200;Min Pool Size=50;TrustServerCertificate=True;"))
                {
                    string sqlStr = @"
                            SELECT * FROM [mydb].[dbo].[User]
                        ";
                    var dynamicParams = new DynamicParameters();
                    var seqList = db.Query<UserModel>(sqlStr, dynamicParams).ToList();
                    result.Data = seqList;
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Messages = $"Message: {ex.Message} |  StackTrace: {ex.StackTrace}";
            }
            return result;
        }

        public ResultModel<List<UserModel>> InsertNewUser(SqlUserModel UserModel)
        {
            ResultModel<List<UserModel>> result = new ResultModel<List<UserModel>>();
            try
            {
                using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-M66CUPJ;Initial Catalog=mydb; Persist Security Info=True;User ID=jack;Password=123456;Connect Timeout=60;Max Pool Size=200;Min Pool Size=50;TrustServerCertificate=True;"))
                {
                    var insertResult = db.InsertAsync(UserModel).Result;
                }
                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Messages = $"Message: {ex.Message} |  StackTrace: {ex.StackTrace}";
            }
            return result;
        }

        public ResultModel<List<CommodityModel>> QueryAllCommodity()
        {
            ResultModel<List<CommodityModel>> result = new ResultModel<List<CommodityModel>>();
            try
            {
                using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-M66CUPJ;Initial Catalog=mydb; Persist Security Info=True;User ID=jack;Password=123456;Connect Timeout=60;Max Pool Size=200;Min Pool Size=50;TrustServerCertificate=True;"))
                {
                    string sqlStr = @"
                            SELECT * FROM [mydb].[dbo].[commodity]
                        ";
                    var dynamicParams = new DynamicParameters();
                    var seqList = db.Query<CommodityModel>(sqlStr, dynamicParams).ToList();
                    result.Data = seqList;
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Messages = $"Message: {ex.Message} |  StackTrace: {ex.StackTrace}";
            }
            return result;
        }
        public ResultModel<List<ShoppingCartJoinCommodityModel>> QueryUserShoppingCart(string userid)
        {
            ResultModel<List<ShoppingCartJoinCommodityModel>> result = new ResultModel<List<ShoppingCartJoinCommodityModel>>();
            try
            {
                using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-M66CUPJ;Initial Catalog=mydb; Persist Security Info=True;User ID=jack;Password=123456;Connect Timeout=60;Max Pool Size=200;Min Pool Size=50;TrustServerCertificate=True;"))
                {
                    string sqlStr = @"
                            SELECT b.name,a.count,b.price,a.cdt,a.udt,a.status,b.id
                              FROM [MyDb].[dbo].[shoppingcart] AS a
                              JOIN [MyDb].[dbo].[commodity] AS b
                                ON a.commodityid = b.Id
                             WHERE userid = @userid and status = 'Open'
                        ";
                    var dynamicParams = new DynamicParameters();
                    dynamicParams.Add("userid", userid);
                    var seqList = db.Query<ShoppingCartJoinCommodityModel>(sqlStr, dynamicParams).ToList();
                    result.Data = seqList;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Messages = $"Message: {ex.Message} |  StackTrace: {ex.StackTrace}";
            }

            return result;
        }


        public ResultModel<List<ShoppingCartJoinCommodityModel>> AddUpdateUserShoppingCart(string userid,string type,ShoppingCartJoinCommodityModel ShoppingCartJoinCommodityModel)
        {
            ResultModel<List<ShoppingCartJoinCommodityModel>> result = new ResultModel<List<ShoppingCartJoinCommodityModel>>();
            try
            {
                using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-M66CUPJ;Initial Catalog=mydb; Persist Security Info=True;User ID=jack;Password=123456;Connect Timeout=60;Max Pool Size=200;Min Pool Size=50;TrustServerCertificate=True;"))
                {
                    if (type == "Add")
                    {
                        var insertResult = db.InsertAsync(ShoppingCartJoinCommodityModel).Result;
                        result.Result = true;
                    }
                    else
                    {
                        string SqlStr = @"
                            UPDATE shoppingcart
                               SET count = @count
                             WHERE userid = @userid and status = 'Open' and commodityid = @commodityid";

                        DynamicParameters updateParam = new DynamicParameters();
                        updateParam.Add("count", ShoppingCartJoinCommodityModel.count);
                        updateParam.Add("commodityid", ShoppingCartJoinCommodityModel.commodityid);
                        updateParam.Add("userid", userid);
                        db.Execute(SqlStr, updateParam);
                        result.Result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Messages = $"Message: {ex.Message} |  StackTrace: {ex.StackTrace}";
            }

            return result;
        }
    }
}
