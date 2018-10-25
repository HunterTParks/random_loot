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
        public MainWindow(List<string> rarityArray)
        {
            InitializeComponent();
            DbConnection(rarityArray);
        }

        void DbConnection(List<string> rarityArray)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Tools\Databases\loot.db;"))
            {
                string query = "SELECT * FROM loot_table WHERE ";
                bool beginningOfQuery = true;

                /*
                 * Remove all null values from array
                 * 
                 */
                for (int i = 0; i <= rarityArray.Count - 1; i++)
                {
                    if (rarityArray[i] == null)
                        rarityArray.RemoveAt(i);
                }

                /*
                 * Add Rarity values to SQL Query
                 *
                 */
                for (int i = 0; i <= rarityArray.Count - 1; i++)
                {
                    if (i == 0 && beginningOfQuery)
                        query += "Rarity = '" + rarityArray[i] + "'";
                    else
                    {
                        query += " OR Rarity = '" + rarityArray[i] + "'";
                    }
                }

                /*
                 * Add semi-colon to end of query to keep SQL syntax
                 * 
                 */
                query += ";";

                /*
                 * Opens connection to local Database and posts data to datagrid
                 * 
                 */
                conn.Open();

                SQLiteCommand command = new SQLiteCommand(query, conn);
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
