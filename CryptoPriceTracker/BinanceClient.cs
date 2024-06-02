using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Clients;

namespace CryptoPriceTracker
{
    internal class BinanceClient : IExchangeClient
    {
        private readonly BinanceSocketClient _socketClient;

        public event Action<IExchangeClient,decimal> OnPriceUpdate;

        public BinanceClient()
        {
            _socketClient = new BinanceSocketClient();
        }

        public async Task ConnectAsync(string symbol)
        {
            await _socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(symbol, data =>
            {
                OnPriceUpdate?.Invoke(this,data.Data.LastPrice);
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
