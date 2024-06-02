using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoPriceTracker
{
    internal interface IExchangeClient
    {
        event Action<IExchangeClient,decimal> OnPriceUpdate;
        
        Task ConnectAsync(string symbol);
        Task DisconnectAsync();

        string FormatSymbol(string symbol);
    }
}
