﻿using Dusza_Fogadas.Models;
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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

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

            if (Game.Games.Any(x => x.Name == txtGameName.Text))
            {
                SuccesBox.Visibility = Visibility.Collapsed;
                ErrorBox.Visibility = Visibility.Visible;
                lblErrorBox.Content = "A game with that name already exists!";
                txtGameName.Text = "";
                txtGameName.Focus();
                return;
            }

            if (subjects.Count < 1 || events.Count < 1)
            {
                MessageBox.Show("You must set at least 1 subject and event!");
                return;
            }

            Game.NewGame(txtGameName.Text, subjects.ToList(), events.ToList());

            ErrorBox.Visibility = Visibility.Collapsed;
            SuccesBox.Visibility= Visibility.Visible;
            lblSuccessBox.Content = "Succesfully created a new game!";
            txtGameName.Text = "";
            events.Clear();
            subjects.Clear();

        }

        private void btnSubjectAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSubject.Text != "" && !subjects.Contains(txtSubject.Text))
            {
                subjects.Add(txtSubject.Text);
                txtSubject.Clear();
                IsValid();
            }
        }

        private void btnEventAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtEvent.Text != "" && !events.Contains(txtEvent.Text))
            {
                events.Add(txtEvent.Text);
                txtEvent.Clear();
                IsValid();
            }
        }

        private void lbSubjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            subjects.Remove(lbSubjects.SelectedItem.ToString());
            IsValid();
        }

        private void lbEvents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            events.Remove(lbEvents.SelectedItem.ToString());
            IsValid();
        }

        private void isValidName(object sender, TextChangedEventArgs e)
        {
            IsValid();
        }

        private void IsValid()
        {
            if (txtGameName.Text.Length >= 3 && lbEvents.Items.Count > 0 && lbSubjects.Items.Count > 0)
                btnCreateGame.IsEnabled = true;
            else
                btnCreateGame.IsEnabled = false;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            HideIcon.RemoveIcon(this);
        }

        private void btnCloseUserNotFound_Click(object sender, RoutedEventArgs e)
        {
            ErrorBox.Visibility = Visibility.Collapsed;
        }

        private void btnSuccessBox_Click(object sender, RoutedEventArgs e)
        {
            SuccesBox.Visibility = Visibility.Collapsed;
        }
    }
}
