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
using Dusza_Fogadas.Models;

namespace Dusza_Fogadas
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame newGame = new NewGame();
            this.Close();
            newGame.Show();
        }

        private void btnBet_Click(object sender, RoutedEventArgs e)
        {
            BetWindow betWindow = new BetWindow();
            this.Close();
            betWindow.Show();
        }

        private void btnEndGame_Click(object sender, RoutedEventArgs e)
        {
            EndGame endGame = new EndGame();
            this.Close();
            endGame.Show();
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            User.Logout();
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            User.Logout();
            this.Close();
        }

    }
}
