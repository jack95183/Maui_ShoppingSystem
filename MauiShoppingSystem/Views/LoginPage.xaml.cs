using MauiShoppingSystem.Services;
using MauiShoppingSystem.ViewModels;

namespace MauiShoppingSystem.Views;

public partial class LoginPage : ContentPage
{
    private LoginPageViewModel _viewModel;
    public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        //CheckHomePage();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.InitHomePageCommand.Execute(null);
    }
    //private readonly IHandleSqliteService _handleSqliteService;
    //private readonly ISqlServerDataAccessService _sqlServerDataAccessService;
    //private readonly IMessageService _messageService;

    //public LoginPage(
    //    IHandleSqliteService handleSqliteService,
    //    ISqlServerDataAccessService sqlServerDataAccessService
    //    )
    //{
    //    _handleSqliteService = handleSqliteService;
    //    _sqlServerDataAccessService = sqlServerDataAccessService;
    //    this._messageService = DependencyService.Get<Services.IMessageService>();
    //}

    //public async void CheckHomePage()
    //{
    //    var configList = await _handleSqliteService.GetConfigList();
    //    if (configList != null)
    //    {
    //        var UserData = configList.Where(i => i.Type.Trim() == "LoginUser").FirstOrDefault();
    //        if (UserData.Value == "")
    //        {
    //            await AppShell.Current.GoToAsync(nameof(LoginPage));
    //        }
    //        else
    //        {
    //            await AppShell.Current.GoToAsync(nameof(ShoppingPage));
    //        }
    //    }
    //}

}