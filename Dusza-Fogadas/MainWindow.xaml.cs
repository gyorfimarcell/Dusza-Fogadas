using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDontHave_Click(object sender, RoutedEventArgs e)
        {
            lblConfirmPassword.Visibility = Visibility.Visible;
            txtConfirmPassword.Visibility = Visibility.Visible;
            btnLogin.Visibility = Visibility.Collapsed;
            btnRegister.Visibility = Visibility.Visible;

            lblAlreadyHave.Visibility = Visibility.Visible;
            btnAlreadyHave.Visibility = Visibility.Visible;

            lblDontHave.Visibility = Visibility.Collapsed;
            btnDontHave.Visibility = Visibility.Collapsed;

            lblTitle.Content = "Register";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlreadyHave_Click(object sender, RoutedEventArgs e)
        {
            lblConfirmPassword.Visibility = Visibility.Collapsed;
            txtConfirmPassword.Visibility = Visibility.Collapsed;
            btnLogin.Visibility = Visibility.Visible;
            btnRegister.Visibility = Visibility.Collapsed;

            lblAlreadyHave.Visibility = Visibility.Collapsed;
            btnAlreadyHave.Visibility = Visibility.Collapsed;

            lblDontHave.Visibility = Visibility.Visible;
            btnDontHave.Visibility = Visibility.Visible;

            lblTitle.Content = "Logn";
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.ShowDialog();
        }
    }
}