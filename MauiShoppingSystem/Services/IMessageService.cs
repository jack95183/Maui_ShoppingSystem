using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiShoppingSystem.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
    }
}
