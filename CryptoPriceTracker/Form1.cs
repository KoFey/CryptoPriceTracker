using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPriceTracker
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<IExchangeClient, ListBox> clientListBoxMap;
        private readonly Dictionary<IExchangeClient, Label> clientLabelMap;
        private readonly List<IExchangeClient> exchangeClients;
        private string selectedSymbol = "BTCUSDT";
        private string quoteCurrency = "USDT";

        public Form1()
        {
            InitializeComponent();

            exchangeClients = new List<IExchangeClient>
            {
                new BinanceClient(),
                new BybitClient(),
                new KucoinClient(),
                new BitgetClient()
            };

            clientListBoxMap = new Dictionary<IExchangeClient, ListBox>
        {
            { exchangeClients[0], listBoxPricesBinance },
            { exchangeClients[1], listBoxPricesBybit },
            { exchangeClients[2], listBoxPricesKucoin },
            { exchangeClients[3], listBoxPricesBitget }
        };

            clientLabelMap = new Dictionary<IExchangeClient, Label>
        {
            { exchangeClients[0], lblCurrentPriceBinance },
            { exchangeClients[1], lblCurrentPriceBybit },
            { exchangeClients[2], lblCurrentPriceKucoin },
            { exchangeClients[3], lblCurrentPriceBitget }
        };


            foreach (var client in exchangeClients)
            {
                client.OnPriceUpdate += (c,price) => Client_OnPriceUpdate(c,price);
            }

            LoadSymbolList();
        }

        private void LoadSymbolList()
        {
            comboBoxSymbols.Items.AddRange(new string[]
            {
            "BTCUSDT", "BTCEUR", "BTCGBP", "BTCJPY", "BTCBUSD", "BTCUSDC",
            "ETHUSDT", "ETHEUR", "ETHGBP", "ETHJPY", "ETHBTC", "ETHBUSD", "ETHUSDC",
            "DOGEUSDT", "DOGEEUR", "DOGEGBP", "DOGEJPY", "DOGEBTC",
            "SOLUSDT", "SOLEUR", "SOLGBP", "SOLJPY", "SOLBTC",
            "UNIUSDT", "UNIEUR", "UNIGBP", "UNIJJPY", "UNIBTC",
            "LTCUSDT", "XRPUSDT", "BCHUSDT", "LINKUSDT", "ADAUSDT", "DOTUSDT", "BNBUSDT",
            "LTCBTC", "XRPBTC", "BCHBTC", "LINKBTC", "ADABTC", "DOTBTC", "BNBBTC", "DOGEBTC", "SOLBTC"
            });
            comboBoxSymbols.SelectedIndex = 0; 
        }

        private void Client_OnPriceUpdate(IExchangeClient client,decimal price)
        {
            if(InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(client,price)));
            }
            else
            {
                UpdateUI(client, price);
            }
        }

        private void UpdateUI(IExchangeClient client, decimal price)
        {
            Console.WriteLine($"Updating UI for {client.GetType().Name} with price {price}");

            string formattedPrice = $"{price} {quoteCurrency}";

            clientListBoxMap[client].Items.Add(formattedPrice);
            clientLabelMap[client].Text = $"Current Price: {formattedPrice}";
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Starting subscriptions...");
            foreach (var client in exchangeClients)
            {
                try
                {
                    string formattedSymbol = client.FormatSymbol(selectedSymbol);
                    await client.ConnectAsync(formattedSymbol);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error subscribing to {client.GetType().Name}: {ex.Message}");
                }
            }
        }
        private async void btnStop_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Stopping subscriptions...");
            foreach (var client in exchangeClients)
            {
                try
                {
                    await client.DisconnectAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error unsubscribing from {client.GetType().Name}: {ex.Message}");
                }
            }
            Console.WriteLine("Subscriptions stopped.");
        }

        private void comboBoxSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSymbol = comboBoxSymbols.SelectedItem.ToString();
            quoteCurrency = ExtractQuoteCurrency(selectedSymbol);
            foreach (var listBox in clientListBoxMap.Values)
            {
                listBox.Items.Clear();
            }
        }
        public string ExtractQuoteCurrency(string symbol)
        {
            var baseCurrencies = new[] { "BTC", "ETH", "DOGE", "SOL", "UNI", "LTC", "XRP", "BCH", "LINK", "ADA", "DOT", "BNB" };

            foreach (var baseCurrency in baseCurrencies)
            {
                if (symbol.StartsWith(baseCurrency))
                {
                    return symbol.Substring(baseCurrency.Length);
                }
            }

            return "USDT";
        }

    }
}
