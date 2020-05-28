using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoneyExchangeApp
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();

            FillDataGrid();

            
        }

        public void FillDataGrid()
        {
            DataTable dataTable = new DataTable();
            string connString = @"data source=(LocalDB)\MSSQLLocalDB;initial catalog=ExchangeDataBase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string query = "select * from ExchangeHistory";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
            dataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("Please select search type!", "Error",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    string searchDate = ConvertToSrting(searchBox.Text);
                    for (int i = 0; i < dataGrid.Items.Count; i++)
                    {
                        string date = (dataGrid.Items[i] as DataRowView).Row[listBox.SelectedIndex].ToString();
                        if (!date.Contains(searchDate))
                        {
                            (dataGrid.Items[i] as DataRowView).Delete();
                            i--;
                        }
                    }
                }


                catch
                {
                }
            }
        }

        private string ConvertToSrting(string dateTime)
        {
            if (dateTime.Contains('/'))
            {
                string[] buf = dateTime.Split('/');

                string d = buf[0];
                string m = buf[1];
                string y = buf[2];

                if(y.Contains(':'))
                {
                    y = y.Split(' ')[0] + ' ' + GetTime(y.Split(' ')[1], y.Split(' ')[2]);                
                }

                if (Convert.ToInt32(d) >= 10)
                    return $"{m}.{d}.{y}";
                else
                    return $"{m}.0{d}.{y}";
            }
            else if (dateTime.Contains(':'))
            {
                return GetTime(dateTime.Split(' ')[0],dateTime.Split(' ')[1]);
            }
            else
            {
                return dateTime;
            }
        }

        private string GetTime(string dateTime, string timeType)
        {
            string[] buf = dateTime.Split(':');
            string h = buf[0];
            string m = buf[1];
            string s = buf[2];

            if(timeType == "AM" && h == "12")
                h = Math.Abs(Convert.ToInt32(h) - 12).ToString();
            else if (timeType == "PM")
            {
                h = Math.Abs(Convert.ToInt32(h) + 12).ToString();
            }
            return $"{h}:{m}:{s}";
        }
    }
}
