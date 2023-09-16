using MauiShoppingSystem.Views;

namespace MauiShoppingSystem;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(ShoppingPage), typeof(ShoppingPage));
        Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
        Routing.RegisterRoute(nameof(ShoppingCartPage), typeof(ShoppingCartPage));

    }
}
