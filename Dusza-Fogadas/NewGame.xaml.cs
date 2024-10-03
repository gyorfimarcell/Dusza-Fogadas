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
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        ObservableCollection<string> subjects = [];
        ObservableCollection<string> events = [];


        public NewGame()
        {
            InitializeComponent();

            lbSubjects.ItemsSource = subjects;
            lbEvents.ItemsSource = events;
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newLoginWindow = new MainWindow();
            this.Close();
            newLoginWindow.ShowDialog();
        }

        private void btnCreateGame_Click(object sender, RoutedEventArgs e)
        {
            if (txtGameName.Text == "")
            {
                MessageBox.Show("Invalid game name!");
                return;
            }

            if (Game.Games.Any(x => x.Name == txtGameName.Name))
            {
                MessageBox.Show("A game with this name already exists!");
                return;
            }

            // TODO: check for at least one event and subject
        }
    }
}
