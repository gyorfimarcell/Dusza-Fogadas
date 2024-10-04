using Dusza_Fogadas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EndGame.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        ObservableCollection<GameResult> results;

        public EndGame()
        {
            InitializeComponent();

            cbGames.ItemsSource = Game.Games.Where(x => !x.IsClosed);
        }

        private void btnEndGame_Click(object sender, RoutedEventArgs e)
        {
            Game game = cbGames.SelectedItem as Game;

            game.CloseGame(results.ToList());

            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }

        private void cbGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game game = cbGames.SelectedItem as Game;

            results = [];
            game.Events.ForEach(ev => game.Subjects.ForEach(sub => results.Add(new(ev, sub))));

            dgSubjectsAndEvents.ItemsSource = results;

            CheckIfCanSubmit();
        }

        private void CheckIfCanSubmit()
        {
            btnEndGame.IsEnabled = cbGames.SelectedIndex != -1 && !results.Any(x => x.Outcome == null || x.Outcome == "");
        }

        private void dgSubjectsAndEvents_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CheckIfCanSubmit();
        }
    }
}
