using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class ShoppingPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private string _wc;
        [ObservableProperty]
        private string _subwc;
        public ObservableCollection<CommodityModel> Commodity {  get; set; } = new ObservableCollection<CommodityModel>();

        private readonly ISqlServerDataAccessService _sqlServerDataAccessService;
        private readonly IHandleSqliteService _handleSqliteService;
        public ShoppingPageViewModel(
            ISqlServerDataAccessService sqlServerDataAccessService,
            IHandleSqliteService handleSqliteService
            )
        {
            _sqlServerDataAccessService = sqlServerDataAccessService;
            _handleSqliteService = handleSqliteService;
        }

        [ICommand]
        public void GetCommodity()
        {

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
        [ICommand]
        public async void Logout()
        {
            SqliteConfigModel SqliteConfigModel = new SqliteConfigModel()
            {
                Type = "LoginUser",
                Value = ""
            };
            await _handleSqliteService.UpdateConfig(SqliteConfigModel);
            await Shell.Current.GoToAsync("//LoginPage", false);
        }
        [ICommand]
        public async void ShoppingGoToAsync()
        {
            await AppShell.Current.GoToAsync(nameof(ShoppingCartPage));
        }

        [ICommand]
        public async void AddShopping()
        {
            var configList = await _handleSqliteService.GetConfigList();
            var UserData = configList.Where(i => i.Type.Trim() == "LoginUser").FirstOrDefault();

            var CommodityList = _sqlServerDataAccessService.QueryUserShoppingCart(UserData.Value);
            var CommodityData = CommodityList.Data.Where(i => i.name.Trim() == "GetnameValue").FirstOrDefault();

            string type = string.Empty;
            if(CommodityData.count > 0)
            {
                type = "Edit";
                CommodityData.count+=1;
                var UserCommodityList = _sqlServerDataAccessService.AddUpdateUserShoppingCart(UserData.Value,type, CommodityData);
            }
            else {
                type = "Add";
                CommodityData.count = 1;
                CommodityData.status = "Open";
                CommodityData.commodityid = 0;
                CommodityData.price = 0;
                var UserCommodityList = _sqlServerDataAccessService.AddUpdateUserShoppingCart(UserData.Value, type, CommodityData);
            }
        }
        [ICommand]
        public async void GetViewListValue()
        {
            await AppShell.Current.GoToAsync(nameof(ShoppingCartPage));
        }



    }
}
