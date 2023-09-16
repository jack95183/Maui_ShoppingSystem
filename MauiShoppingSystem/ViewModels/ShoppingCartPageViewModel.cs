using MauiShoppingSystem.Models;
using MauiShoppingSystem.Services;
using MauiShoppingSystem.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiShoppingSystem.ViewModels
{
    public partial class ShoppingCartPageViewModel : ObservableObject
    {
        private readonly IHandleSqliteService _handleSqliteService;
        private readonly ISqlServerDataAccessService _sqlServerDataAccessService;
        private readonly IMessageService _messageService;

        public ShoppingCartPageViewModel(
            IHandleSqliteService handleSqliteService,
            ISqlServerDataAccessService sqlServerDataAccessService
            )
        {
            _handleSqliteService = handleSqliteService;
            _sqlServerDataAccessService = sqlServerDataAccessService;
            this._messageService = DependencyService.Get<Services.IMessageService>();
        }
        public ObservableCollection<ShoppingCartJoinCommodityModel> UserCommodity { get; set; } = new ObservableCollection<ShoppingCartJoinCommodityModel>();


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
        public async void GetUserCommodity()
        {
            // 更新token
            var configList = await _handleSqliteService.GetConfigList();
            var UserData = configList.Where(i => i.Type.Trim() == "LoginUser").FirstOrDefault();
            var list = _sqlServerDataAccessService.QueryUserShoppingCart(UserData.Value);

            if (list.Data?.Count > 0)
            {
                UserCommodity.Clear();
                foreach (ShoppingCartJoinCommodityModel config in list.Data)
                {
                    UserCommodity.Add(config);
                }
            }
        }

        [ICommand]
        public async void ShoppingGoToAsync()
        {
            await AppShell.Current.GoToAsync(nameof(ShoppingPage));
        }


    }
}

