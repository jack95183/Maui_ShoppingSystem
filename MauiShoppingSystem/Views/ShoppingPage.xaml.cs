using MauiShoppingSystem.ViewModels;

namespace MauiShoppingSystem.Views;

public partial class ShoppingPage : ContentPage
{
    private ShoppingPageViewModel _viewModel;
    public ShoppingPage(ShoppingPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing(); 
        _viewModel.GetCommodityCommand.Execute(null);
        //_viewModel.GetUserIdCommand.Execute(null);
    }
}