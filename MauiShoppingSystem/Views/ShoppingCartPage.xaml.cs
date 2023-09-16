using MauiShoppingSystem.ViewModels;

namespace MauiShoppingSystem.Views;

public partial class ShoppingCartPage : ContentPage
{
    private ShoppingCartPageViewModel _viewModel;
    public ShoppingCartPage(ShoppingCartPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetUserCommodityCommand.Execute(null);

    }

}