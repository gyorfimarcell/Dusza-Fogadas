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

            if (subjects.Count < 1 || events.Count < 1)
            {
                MessageBox.Show("You must set at least 1 subject and event!");
                return;
            }

            Game.NewGame(txtGameName.Text, subjects.ToList(), events.ToList());

            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }

        private void btnSubjectAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSubject.Text != "" && !subjects.Contains(txtSubject.Text))
            {
                subjects.Add(txtSubject.Text);
                txtSubject.Clear();
            }
        }

        private void btnEventAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtEvent.Text != "" && !events.Contains(txtEvent.Text))
            {
                events.Add(txtEvent.Text);
                txtEvent.Clear();
            }
        }

        private void lbSubjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            subjects.Remove(lbSubjects.SelectedItem.ToString());
        }

        private void lbEvents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            events.Remove(lbEvents.SelectedItem.ToString());
        }
    }
}
