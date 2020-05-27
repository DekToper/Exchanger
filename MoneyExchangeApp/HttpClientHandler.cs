using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyExchangeApp
{
    public class HttpClientHandler
    {

        public static double GetExchangeRateAsync(string currency)
        {
            if (currency == "EUR")
            {
                return 0;
            }
            else
            {
                if (InternetCS.IsConnectedToInternet())
                {
                    WebClient client = new WebClient();

                    string content = client.DownloadString($"https://api.exchangeratesapi.io/latest?symbols={currency}");

                    if (content != "")
                    {

                        ExchangeRate exchangeRate = JsonConvert.DeserializeObject<ExchangeRate>(content);

                        foreach (double item in exchangeRate.rates)
                        {
                            return item;
                        }

                    }
                    return 0;
                }
                else
                {
                    MessageBox.Show("Make sure your internet connection is working normally. If your internet connection is unstable, learn how to fix internet stability issues.",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }
            }
        }


    }
}
