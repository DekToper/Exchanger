using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MoneyExchangeApp
{
    class ClickHandler
    {
        private MainWindow mainWindow;

        public ClickHandler(MainWindow m)
        {
            mainWindow = m;
        }

        internal void ReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem listViewItem = mainWindow.currencyFrom.Items[0] as ListViewItem;
            ReplaceItems(listViewItem, mainWindow.currencyTo,mainWindow.currencyFrom);
            mainWindow.resaultLabel.Content = "";
            mainWindow.amountBox.Text = "";
        }

        private void ReplaceItems(ListViewItem selectedItem, ListView toListView, ListView fromListView)
        {
            ListViewItem bufferFrom = selectedItem;

            ListViewItem bufferTo = toListView.Items[0] as ListViewItem;

            toListView.Items.Clear();
            fromListView.Items.Clear();

            fromListView.Items.Add(bufferTo);
            toListView.Items.Add(bufferFrom);
        }

        internal void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            HistoryWindow historyWindow = new HistoryWindow();
            historyWindow.ShowDialog();
        }

        internal void ExchangeButton_Click(object sender, RoutedEventArgs e)
        {
            string fromCurrency = ((mainWindow.currencyFrom.Items[0] as ListViewItem).Content as Frame).Name;
            string toCurrency = ((mainWindow.currencyTo.Items[0] as ListViewItem).Content as Frame).Name;
            if (fromCurrency == toCurrency)
            {
                mainWindow.erroreLabel.Content = "The currency you want to exchange is the same as the currency you want to receive.";
            }
            else
            {
                mainWindow.erroreLabel.Content = "";
                try
                {
                    double value = Convert.ToDouble(mainWindow.amountBox.Text);
                    Task t = Task.Run(new Action(() =>
                    {
                        double from = HttpClientHandler.GetExchangeRateAsync(fromCurrency);

                        double to = HttpClientHandler.GetExchangeRateAsync(toCurrency);

                        mainWindow.Dispatcher.Invoke(new Action(() => 
                        {
                            double result = GetResult(value, from, to);
                            mainWindow.resaultLabel.Content = result.ToString();

                            ExchangeHistory e = new ExchangeHistory();
                            e.Date = DateTime.Now;
                            e.FromCurrency = fromCurrency;
                            e.FromAmount = value;
                            e.ToCurrency = toCurrency;
                            e.ToAmount = result;
                            Serialize(e);
                        }));

                    }));
                    
                    
                }
                catch
                {
                    mainWindow.erroreLabel.Content = "You entered an incorrect value!";
                }

            }
        }

        private void Serialize(ExchangeHistory exchangeHistory)
        {
            using (Model model = new Model())
            {
                model.ExchangeHistory.Add(exchangeHistory);
                model.SaveChanges();
            }
        }

        private double GetResult(double value, double from, double to)
        {
            //I used this check because Api on that site does not contain EUR
            double result = 0;
            if(from == 0)
            {
                result = value * to;
            }
            else if (to == 0)
            {
                result = value / from;
            }
            else
                result = (value / from) * to;
            return result;
        }

        internal void ToButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow.toFrame.Visibility == Visibility.Visible)
            {
                mainWindow.toFrame.Visibility = Visibility.Hidden;
                mainWindow.toButton.Content = "⮟";
            }
            else
            {
                string currency = GetCurrencyName(mainWindow.currencyTo);
                ListView listView = CreateListView(currency, sender);
                mainWindow.toFrame.Navigate(listView);
                mainWindow.toFrame.Visibility = Visibility.Visible;
                mainWindow.toButton.Content = "⮝";
            }
        }

        internal void FromButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow.fromFrame.Visibility == Visibility.Visible)
            {
                mainWindow.fromFrame.Visibility = Visibility.Hidden;
                mainWindow.fromButton.Content = "⮟";
            }
            else
            {
                string currency = GetCurrencyName(mainWindow.currencyFrom);
                ListView listView = CreateListView(currency, sender);
                mainWindow.fromFrame.Navigate(listView);
                mainWindow.fromFrame.Visibility = Visibility.Visible;
                mainWindow.fromButton.Content = "⮝";
            }
        }

        private string GetCurrencyName(ListView listView)
        {
            string currency = ((listView.Items[0] as ListViewItem).Content as Frame).Name;

            return currency;
        }

        private ListView CreateListView(string currentCurrency, object sender)
        {
            ListView listView = new ListView();
            string[] paths = Directory.GetFiles("..\\..\\..\\Resources");

            foreach(string item in paths)
            {
                if(!item.Contains(currentCurrency))
                {
                    int parts = item.Split('\\').Length;
                    string lastPart = item.Split('\\')[parts-1];
                    string currency = lastPart.Replace("flag", "").Replace(".png","");
                    listView.Items.Add(AppConfig.GetItem(currency));
                }
            }

            if((sender as Button).Name == "fromButton")
                listView.SelectionChanged += SelectioChangedFrom;
            else
                listView.SelectionChanged += SelectioChangedTo;


            return listView;
        }

        private void SelectioChangedFrom(object sender, SelectionChangedEventArgs e)
        {
            if (mainWindow.currencyFrom.Items.Count != 0)
            {
                ReplaceItems((sender as ListView).SelectedItem as ListViewItem, mainWindow.currencyFrom, (sender as ListView));

                mainWindow.fromFrame.Visibility = Visibility.Hidden;
                mainWindow.fromButton.Content = "⮟";
            }
        }

        private void SelectioChangedTo(object sender, SelectionChangedEventArgs e)
        {
            if (mainWindow.currencyTo.Items.Count != 0)
            {
                ReplaceItems((sender as ListView).SelectedItem as ListViewItem, mainWindow.currencyTo, (sender as ListView));

                mainWindow.toFrame.Visibility = Visibility.Hidden;
                mainWindow.toButton.Content = "⮟";
            }
        }
    }
}
