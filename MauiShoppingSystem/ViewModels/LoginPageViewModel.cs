using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using IdentityModel.OidcClient;
using MauiShoppingSystem.Models;
using MauiShoppingSystem.Services;
using MauiShoppingSystem.Views;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiShoppingSystem.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _userid;
        [ObservableProperty]
        private string _password;

        private readonly IHandleSqliteService _handleSqliteService;
        private readonly ISqlServerDataAccessService _sqlServerDataAccessService;
        private readonly IMessageService _messageService;

        public LoginPageViewModel(
            IHandleSqliteService handleSqliteService,
            ISqlServerDataAccessService sqlServerDataAccessService
            )
        {
            _handleSqliteService = handleSqliteService;
            _sqlServerDataAccessService = sqlServerDataAccessService;
            this._messageService = DependencyService.Get<Services.IMessageService>();
        }
        public ObservableCollection<CommodityModel> Commodity { get; set; } = new ObservableCollection<CommodityModel>();


        //[ICommand]
        //public async void AddUpdateConfig(string Type)
        //{
        //    int response = -1;
        //    if (SqliteConfi != "")
        //    {
        //        response = await _handleSqliteService.UpdateConfig(SqliteConfig);
        //    }
        //    await AppShell.Current.GoToAsync(nameof(ShoppingPage));
        //    response = await _handleSqliteService.AddConfig(new Models.SqliteConfigModel
        //    {
        //        Type = Userid,
        //        Value = Password
        //    });

        //    if(response > 0)
        //    {
        //        await Shell.Current.DisplayAlert("Record Add","success", "OKK");
        //    }
        //    else
        //    {
        //        await Shell.Current.DisplayAlert("Record 0", "success", "NOKK");
        //    }
        //}
        [ICommand]
        public async void Login()
        {
            //查MSSQL檢查帳密
            var QueryAllUserResult = _sqlServerDataAccessService.QueryAllUser();
            var WhererUserData = QueryAllUserResult.Data.Where(i => i.userid.Trim() == Userid).FirstOrDefault();
            if (WhererUserData != null)
            {
                if (WhererUserData.password.Trim() == Password)
                {
                    // 更新token
                    var configList = await _handleSqliteService.GetConfigList();
                    var UserData = configList.Where(i => i.Type.Trim() == "LoginUser").FirstOrDefault();
                    //if (configList?.Count > 0)
                    //{
                    //sqliteConfig.Clear();
                    //foreach (var config in configList)
                    //{
                    //    sqliteConfig.Add(config);
                    //}

                    //}
                    SqliteConfigModel SqliteConfigModel = new SqliteConfigModel()
                    {
                        Type = "LoginUser",
                        Value = Userid
                    };
                    if (UserData == null)
                    {

                        await _handleSqliteService.AddConfig(SqliteConfigModel);
                    }
                    else if (UserData.Value == "" || UserData.Value == null)
                    {
                        await _handleSqliteService.UpdateConfig(SqliteConfigModel);
                    }
                    await AppShell.Current.GoToAsync(nameof(ShoppingPage));
                    var CommodityList = _sqlServerDataAccessService.QueryAllCommodity();
                    if (CommodityList.Data?.Count > 0)
                    {
                        Commodity.Clear();
                        foreach (var config in CommodityList.Data)
                        {
                            Commodity.Add(config);
                        }
                    }
                }
                else
                {
                    await _messageService.ShowAsync("登入失敗，密碼錯誤");
                }
            }
            else
            {
                await _messageService.ShowAsync("登入失敗，查無此帳號");
            }

        }

        [ICommand]
        public async void SignUpGoToAsync()
        {
            await AppShell.Current.GoToAsync(nameof(SignupPage));
        }



        //Sqlite Userid數據為空就到login頁面，否則到shopping頁面
        [ICommand]
        public async void InitHomePage()
        {
            var configList = await _handleSqliteService.GetConfigList();
            var UserData = configList.Where(i => i.Type.Trim() == "LoginUser").FirstOrDefault();
            if (UserData == null || UserData.Value == "" || UserData.Value == null)
            {
                await AppShell.Current.GoToAsync("//LoginPage", false);
                Password = "";
            }
            else
            {
                await AppShell.Current.GoToAsync(nameof(ShoppingPage));
            }

        }
    }
}
