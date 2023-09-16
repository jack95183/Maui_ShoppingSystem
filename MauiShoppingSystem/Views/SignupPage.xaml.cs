using MauiShoppingSystem.ViewModels;

namespace MauiShoppingSystem.Views;

public partial class SignupPage : ContentPage
{
    private SignupPageViewModel _viewModel;
    public SignupPage(SignupPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }
}