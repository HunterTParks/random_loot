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
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Collections.ObjectModel;

namespace random_loot
{
    /// <summary>
    /// Interaction logic for RandomItemWindow.xaml
    /// </summary>
    public partial class RandomItemWindow : Window
    {
        public RandomItemWindow(List<string> rarityArray)
        {
            InitializeComponent();
            DbConnection(rarityArray);
        }

        /*
         * This function opens a connection to a local database and gets a random
         * item using the user's input
         * 
         */
        void DbConnection(List<string> rarityArray)
        {
            List<Item> list = new List<Item>();
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
                query += " ORDER BY RANDOM() LIMIT 1;";

                /*
                 * Opens connection to local Database and posts data to datagrid
                 * 
                 */
                conn.Open();

                /*
                 * This section reads the table in the database and posts the information
                 * to the datagrid.
                 * 
                 */
                SQLiteCommand command = new SQLiteCommand(query, conn);
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataAdapter.Fill(dataTable);
                    RandomSource.ItemsSource = dataTable.DefaultView;
                }

                conn.Close();
            }
        }
    }
}
