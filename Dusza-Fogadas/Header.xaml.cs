using Dusza_Fogadas.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dusza_Fogadas
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public string Title { get; set; }

        public Header()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitle.Content = Title;
            lblUsername.Content = User.CurrentUser?.Username;
            UpdatePoints();
        }

        public void UpdatePoints() {
            if (User.CurrentUser?.Role == UserRole.Player)
            {
                lblPoints.Content = $"${User.CurrentUser.Balance}";
            }
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
            menu.Show();
        }
    }
}
