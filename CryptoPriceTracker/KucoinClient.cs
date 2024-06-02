using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kucoin.Net;
using Kucoin.Net.Clients;

namespace CryptoPriceTracker
{
    internal class KucoinClient : IExchangeClient
    {
        private readonly KucoinSocketClient _socketClient;
        public event Action<IExchangeClient,decimal> OnPriceUpdate;

        public KucoinClient()
        {
            _socketClient = new KucoinSocketClient();
        }

        public async Task ConnectAsync(string symbol)
        {
            try
            {
                await _socketClient.SpotApi.SubscribeToTickerUpdatesAsync(symbol, data =>
                {
                    OnPriceUpdate?.Invoke(this, (decimal)data.Data.LastPrice);
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to Kucoin: {ex.Message}");
            }
        }

        public async Task DisconnectAsync()
        {
            await _socketClient.UnsubscribeAllAsync();
        }

        public string FormatSymbol(string symbol)
        {
            // Определение списка базовых валют
            var baseCurrencies = new[] { "BTC", "ETH", "DOGE", "SOL", "UNI", "LTC", "XRP", "BCH", "LINK", "ADA", "DOT", "BNB" };

            foreach (var baseCurrency in baseCurrencies)
            {
                if (symbol.StartsWith(baseCurrency))
                {
                    string quoteCurrency = symbol.Substring(baseCurrency.Length);
                    return $"{baseCurrency}-{quoteCurrency}";
                }
            }

            // Если не удалось определить базовую валюту, возвращаем символ без изменений
            return symbol;
        }
    }
}
