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
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        public Statistics()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            HideIcon.RemoveIcon(this);
        }

        private void btnRankings_Click(object sender, RoutedEventArgs e)
        {
            Rankings newRankings = new Rankings();
            this.Close();
            newRankings.Show();
        }

        private void btnGameStatistics_Click(object sender, RoutedEventArgs e)
        {
            GameStatisticsWindow newGameStatistics = new GameStatisticsWindow();
            this.Close();
            newGameStatistics.Show();
        }

        private void btnBetStatistics_Click(object sender, RoutedEventArgs e)
        {
            BetStatisticsWindow newBetStatistics = new BetStatisticsWindow();
            this.Close();
            newBetStatistics.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu newMenu = new Menu();
            this.Close();
            newMenu.Show();
        }
    }
}
