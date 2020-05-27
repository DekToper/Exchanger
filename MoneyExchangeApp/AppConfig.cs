using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Interop;

namespace MoneyExchangeApp
{
    public class AppConfig
    {
        public static void Load(MainWindow window)
        {
            ClickHandler clickHandler = new ClickHandler(window);

            window.currencyFrom.Items.Add(GetItem("USD"));
            window.currencyTo.Items.Add(GetItem("RUB"));

            window.replaceButton.Click += clickHandler.ReplaceButton_Click;
            window.fromButton.Click += clickHandler.FromButton_Click;
            window.toButton.Click += clickHandler.ToButton_Click;
            window.exchangeButton.Click += clickHandler.ExchangeButton_Click;
            window.historyButton.Click += clickHandler.HistoryButton_Click;
        }

        public static System.Windows.Controls.ListViewItem GetItem(string currency)
        {
            System.Windows.Controls.ListViewItem listViewItem = new System.Windows.Controls.ListViewItem();

            string path = $"../../../Resources/flag{currency}.png";
            Image img = Image.FromFile(path);
            Bitmap bitmap = new Bitmap(img);
            IntPtr hBitmap = bitmap.GetHbitmap();

            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = Imaging.CreateBitmapSourceFromHBitmap(
                            hBitmap, IntPtr.Zero, Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());

            CurrencyPage currencyPage = new CurrencyPage();
            currencyPage.currencyName.Content = currency;
            currencyPage.currencyImage.Source = image.Source;

            System.Windows.Controls.Frame frame = new System.Windows.Controls.Frame();
            frame.Navigate(currencyPage);
            frame.Name = currency;

            listViewItem.Content = frame;
            listViewItem.VerticalAlignment = VerticalAlignment.Center;

            return listViewItem;
        }

    }

}
