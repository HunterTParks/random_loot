using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace random_loot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string[] rarityArray)
        {
            InitializeComponent();
        }

        void DbConnection(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Tools\Databases\loot.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("SELECT * FROM LOOT_TABLE;", conn);
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataAdapter.Fill(dataTable);
                    Grid.ItemsSource = dataTable.DefaultView;
                }
              
                conn.Close();
            }
        }
    }
}
