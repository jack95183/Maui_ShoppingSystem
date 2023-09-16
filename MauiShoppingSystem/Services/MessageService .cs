using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiShoppingSystem.Services
{
    public class MessageService: IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Notice", message, "Ok");
        }
    }
}
