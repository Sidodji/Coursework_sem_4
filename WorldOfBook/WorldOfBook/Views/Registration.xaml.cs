using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using MaterialDesignThemes.Wpf;
using WorldOfBook.Properties;
using System.Data;
using System.Security.Cryptography;

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для Redistration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9800"));

        public Registration()
        {
            InitializeComponent();
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {

            User user = new User()
            {
                Name = NameUser.Text, Surname = SurnameUser.Text, Username = UsernameUser.Text, Password = GetHash(PasswordUser.Password)
            };

            User authUser = null;
            try
            {
                using (User_Context userdb = new User_Context())
                {
                    authUser = userdb.UserContext.Where(b => b.Username == UsernameUser.Text).FirstOrDefault();
                    if (authUser == null)
                    {
                        var udb = userdb.UserContext;
                        udb.Add(user);
                        userdb.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("This nickname is busy");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter correct data");
            }
           
        }

        private void ReadyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegSurnameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            RegSurname.Foreground = color;
        }

        private void RegNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            RegName.Foreground = color;
        }

        private void RegUserNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            RegUserName.Foreground = color;
        }

        private void RegPasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            RegPassword.Foreground = color;
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization autho = new Authorization();
            this.Close();
            autho.Show();
        }
    }
}
