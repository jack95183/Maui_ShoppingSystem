using MauiShoppingSystem.Services;
using MauiShoppingSystem.ViewModels;
using MauiShoppingSystem.Views;

namespace MauiShoppingSystem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Services
        builder.Services.AddSingleton<IHandleSqliteService, HandleSqliteService>();
        builder.Services.AddSingleton<ISqlServerDataAccessService, SqlServerDataAccessService>();
        builder.Services.AddSingleton<IMessageService, MessageService>();

        //Views Registration
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<ShoppingPage>();
        builder.Services.AddSingleton<ShoppingCartPage>();
        builder.Services.AddSingleton<SignupPage>();

        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<ShoppingPageViewModel>();
        builder.Services.AddSingleton<ShoppingCartPageViewModel>();
        builder.Services.AddSingleton<SignupPageViewModel>();


        return builder.Build();
	}
}
