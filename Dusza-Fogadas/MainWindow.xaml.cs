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

using Dusza_Fogadas.Models;

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
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            string usernameErrorMessage = CheckUsername(username);
            string passwordErrorMessage = CheckPassword(password);

            if (usernameErrorMessage == "" && passwordErrorMessage == "")
            {
                try
                {
                    User.RegisterUser(username, password);
                    Menu menuWindow = new Menu();
                    this.Close();
                    menuWindow.ShowDialog();
                }
                catch (ArgumentException)
                {
                    throw;
                }             
            }
            else
            {
                lblUsernameError.Content = usernameErrorMessage;
                lblPasswordError.Content = passwordErrorMessage;
                lblConfirmPasswordError.Content = passwordErrorMessage;

                if (usernameErrorMessage != "")
                    txtUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                if (passwordErrorMessage != "")
                { 
                    txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtConfirmPassword.BorderBrush = new SolidColorBrush(Colors.Red) ;
                }
            }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            string usernameErrorMessage = CheckUsername(username);
            string passwordErrorMessage = CheckPassword(password);

            if (usernameErrorMessage == "" && passwordErrorMessage == "")
            {
                try
                {
                    if (!User.TryLogin(username, password))
                        MessageBox.Show("This user does not exist!");
                    else
                    {
                        User.TryLogin(username, password);
                        Menu menuWindow = new Menu();
                        this.Close();
                        menuWindow.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorect Password!");
                    throw;
                }                  
            }
            else
            {
                lblUsernameError.Content = usernameErrorMessage;
                lblPasswordError.Content = passwordErrorMessage;

                if (usernameErrorMessage != "")
                    txtUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                if (passwordErrorMessage != "")
                    txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
            }
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
            ResetErrorMessages();
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

            lblTitle.Content = "Login";
            ResetErrorMessages();

        }

        private void ResetErrorMessages(){
            lblConfirmPasswordError.Content = "";
            lblPasswordError.Content = "";
            lblUsernameError.Content = "";
        }

        private string CheckUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return "No username!";
            }
            else if (username.Length < 3)
            {
                return "Username must be at least 3 character long!";
            }
            else
                return "";
        }

        private string CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return "No password!";
            }
            else if (password.Length < 6)
            {
                return "Password must be at least 6 characters long!";
            }
            else if (!password.Any(c => char.IsDigit(c)))
            {
                return "Password must contain a number!";
            }
            else if (!password.Any(c => char.IsUpper(c)))
            {
                return "Password must contain an uppercase character!";
            }
            else if (txtConfirmPassword.Visibility == Visibility.Visible && txtConfirmPassword.Password != password)
            {
                return "Password and Confirmation must be the same!";
            }
            else
            {
                return "";
            }
        }

        private void RemoveErrorOutline(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox) { 
                TextBox textBox = sender as TextBox;
                textBox.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            if (sender is PasswordBox) { 
                PasswordBox textBox = sender as PasswordBox;
                textBox.BorderBrush = new SolidColorBrush(Colors.Black);
            }
        }
    }
}