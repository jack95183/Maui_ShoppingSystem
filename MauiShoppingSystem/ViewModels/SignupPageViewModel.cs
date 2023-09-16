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
    public partial class SignupPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _userid;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _address;
        [ObservableProperty]
        private int _age;
        [ObservableProperty]
        private string _phone;
        [ObservableProperty]
        private string _checkpassword;


        private readonly IHandleSqliteService _handleSqliteService;
        private readonly ISqlServerDataAccessService _sqlServerDataAccessService;
        private readonly IMessageService _messageService;

        public SignupPageViewModel(
            IHandleSqliteService handleSqliteService,
            ISqlServerDataAccessService sqlServerDataAccessService
            )
        {
            _handleSqliteService = handleSqliteService;
            _sqlServerDataAccessService = sqlServerDataAccessService;
            this._messageService = DependencyService.Get<Services.IMessageService>();
        }

        [ICommand]
        public async void SignUpUser()
        {
            SqlUserModel SqlUserModel = new SqlUserModel
            {
                name = Name,
                phone = Phone,
                address = Address,
                age = Age,
                userid = Userid,
                password = Password,
            };

            //查MSSQL檢查UserId是否重複，沒重複新增，重複跳通知
            var QueryAllUserResult = _sqlServerDataAccessService.QueryAllUser();
            var WhererUserData = QueryAllUserResult.Data.Where(i => i.userid.Trim() == Userid).FirstOrDefault();
            if (WhererUserData != null)
            {
                await _messageService.ShowAsync("註冊失敗，帳號已有人使用");

            }
            else if (Checkpassword != Password)
            {
                await _messageService.ShowAsync("註冊失敗，密碼不一致");
            }
            else if (Name == "" || Name == null && Userid == "" || Userid == null && Password == "" || Password == null)
            {
                await _messageService.ShowAsync("註冊失敗，姓名、帳號、密碼不得為空");
            }
            else
            {
                _sqlServerDataAccessService.InsertNewUser(SqlUserModel);
                await _messageService.ShowAsync("註冊成功");
                await AppShell.Current.GoToAsync("//LoginPage", false);

            }
        }

        [ICommand]
        public async void LoginGoToAsync()
        {
            await AppShell.Current.GoToAsync("//LoginPage", false);
        }
    }
}
