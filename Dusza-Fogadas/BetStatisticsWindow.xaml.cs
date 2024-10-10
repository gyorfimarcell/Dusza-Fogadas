using Dusza_Fogadas.Models;
using Dusza_Fogadas.Models.Statistics;
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
    /// Interaction logic for BetStatisticsWindow.xaml
    /// </summary>
    public partial class BetStatisticsWindow : Window
    {
        public BetStatisticsWindow()
        {
            InitializeComponent();

            cbGame.ItemsSource = Game.Games;
        }

        private void cbGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbGame.SelectedIndex != -1)
            {
                Game game = cbGame.SelectedItem as Game;
                dgStatistics.ItemsSource = BetStatistics.GetStatistics(game);
            }
        }
    }
}
