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
                    for (int i = 0; i < dataGrid.Items.Count; i++)
                    {
                        if (!(dataGrid.Items[i] as DataRowView).Row[listBox.SelectedIndex].ToString().Contains(searchBox.Text))
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
    }
}
