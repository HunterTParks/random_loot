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

namespace random_loot
{
    /// <summary>
    /// Interaction logic for SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {
        private string[] rarityArray = new string[6];
        public SelectionWindow()
        {
            InitializeComponent();
        }

        public void Window_Event(object sender, RoutedEventArgs e)
        {
            rarityArray[0] = Mundane.IsChecked == true ? "Mundane" : "";
            rarityArray[1] = Common.IsChecked == true ? "Common" : "";
            rarityArray[2] = Uncommon.IsChecked == true ? "Uncommon" : "";
            rarityArray[3] = Rare.IsChecked == true ? "Rare" : "";
            rarityArray[4] = Legendary.IsChecked == true ? "Legendary" : "";
            rarityArray[5] = Misc.IsChecked == true ? "Misc" : "";
            MainWindow window2 = new MainWindow(rarityArray);
            window2.Show();
        }
    }
}
