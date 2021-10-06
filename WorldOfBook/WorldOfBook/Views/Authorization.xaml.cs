using MaterialDesignThemes.Wpf;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Data;
using WorldOfBook.Properties;
using System.Security.Cryptography;


namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            List<User> userList = new List<User>();
            using (User_Context userdb = new User_Context())
            {
                int count = 0;
                var udb = userdb.UserContext;
                foreach (User user in udb)
                {
                    
                    if (UserName.Text == user.Username && GetHash(PasswordPlace.Password) == user.Password)
                    {
                        if (user.Username == "Admin" && user.Password == "46/tAEewgFnQ+toQ9ADB5Q==")
                        {
                            MainWindow mainWindow = new MainWindow(true);
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            if(user.Block_Id==0)
                            {
                                MainWindow.CurrentUserId = user.Id;
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                userList.Add(user);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Contact the Administrator");
                            }
                        }
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if (count == udb.Count())
                {
                    Icon1.Foreground = Brushes.Red;
                    Icon2.Foreground = Brushes.Red;
                    MessageBox.Show("Invalid username or password \n Please, try again");
                }
            }
        }

        private void CreateAccButton_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }

        private void UserNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            //Icon1.Foreground = color;
        }

        private void PasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            //    Icon2.Foreground = color;
        }

        private void UserNameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CloseButt_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

