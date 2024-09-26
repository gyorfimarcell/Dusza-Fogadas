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
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        public NewGame()
        {
            InitializeComponent();
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newLoginWindow = new MainWindow();
            this.Close();
            newLoginWindow.ShowDialog();
        }

        private void btnCreateGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
