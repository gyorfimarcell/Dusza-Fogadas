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

namespace Dusza_Fogadas
{
    /// <summary>
    /// Interaction logic for BetWindow.xaml
    /// </summary>
    public partial class BetWindow : Window
    {
        public BetWindow()
        {
            InitializeComponent();

        }

        private void btnBet_Click(object sender, RoutedEventArgs e)
        {
            string chosenGame = cbGameName.SelectedItem.ToString();
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }
    }
}
