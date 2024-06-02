using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitget.Net.Clients;

namespace CryptoPriceTracker
{
    internal class BitgetClient : IExchangeClient
    {
        private readonly BitgetSocketClient _socketClient;
        public event Action<IExchangeClient,decimal> OnPriceUpdate;

        public BitgetClient()
        {
            _socketClient = new BitgetSocketClient();
        }

        public async Task ConnectAsync(string symbol)
        {
            await _socketClient.SpotApi.SubscribeToTickerUpdatesAsync(symbol, data =>
            {
                OnPriceUpdate?.Invoke(this, data.Data.LastPrice);
            });
        }

        public async Task DisconnectAsync()
        {
            await _socketClient.SpotApi.UnsubscribeAllAsync();
        }

        public string FormatSymbol(string symbol)
        {
            return symbol;
        }
    }
}
