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
    /// Interaction logic for BetWindow.xaml
    /// </summary>
    public partial class BetWindow : Window
    {
        public BetWindow()
        {
            
            InitializeComponent();
            cbGame.ItemsSource = Game.Games.Where(x => !x.IsClosed);
            
        }
        private void cbGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbEvent.IsEnabled = true;
            cbSubject.IsEnabled = true;
            txtOutcome.IsEnabled = true;
            txtBetAmount.IsEnabled = true;

            cbEvent.ItemsSource = (cbGame.SelectedItem as Game).Events;
            cbSubject.ItemsSource = (cbGame.SelectedItem as Game).Subjects;


        }

        private void btnBet_Click(object sender, RoutedEventArgs e)
        {
 
            string outcome = txtOutcome.Text;
            int amount = Convert.ToInt32(txtBetAmount.Text);
            try
            {
                Bet.PlaceBet((cbGame.SelectedItem as Game).Id, (cbSubject.SelectedItem as GameSubject).Id, (cbEvent.SelectedItem as GameEvent).Id, outcome, amount);
                MessageBox.Show("Successfully placed bet!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtBetAmount.Text = "";
            txtOutcome.Text = "";
            header.UpdatePoints();

        }

        private void CheckIfCanBetCB(object sender, SelectionChangedEventArgs e)
        {
            if (canBet()) { btnBet.IsEnabled = true;}
            else { btnBet.IsEnabled = false;}
        }

        private void CheckIfCanBetTXT(object sender, TextChangedEventArgs e)
        {
            if (canBet()) { btnBet.IsEnabled = true; }
            else { btnBet.IsEnabled = false; }
        }

        private bool canBet()
        {
            if (cbEvent.SelectedIndex != -1 && cbSubject.SelectedIndex != -1 && txtBetAmount.Text != "" && txtOutcome.Text != "")
            {
                return true;
            }
            else
                return false;
        }
    }
}
