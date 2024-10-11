﻿using Dusza_Fogadas.Models.Statistics;
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
    /// Interaction logic for Rankings.xaml
    /// </summary>
    public partial class Rankings : Window
    {
        public Rankings()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            dgRankings.ItemsSource = Ranking.GetRankings();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            HideIcon.RemoveIcon(this);
        }
    }
}
