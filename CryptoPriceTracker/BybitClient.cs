using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bybit.Net.Clients;

namespace CryptoPriceTracker
{
    internal class BybitClient : IExchangeClient
    {
        private readonly BybitSocketClient _socketClient;
        public event Action<IExchangeClient,decimal> OnPriceUpdate;

        public BybitClient()
        {
            _socketClient = new BybitSocketClient();
        }

        public async Task ConnectAsync(string symbol)
        {
            await _socketClient.SpotV3Api.SubscribeToTickerUpdatesAsync(symbol, data =>
            {
                OnPriceUpdate?.Invoke(this, data.Data.LastPrice);
            });
        }

        public async Task DisconnectAsync()
        {
            await _socketClient.SpotV3Api.UnsubscribeAllAsync();
        }

        public string FormatSymbol(string symbol)
        {
            return symbol;
        }
    }
}
