namespace MauiShoppingSystem;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        //Add the next line
        DependencyService.Register<Services.IMessageService, Services.MessageService>();
        InitializeComponent();
    }
}
