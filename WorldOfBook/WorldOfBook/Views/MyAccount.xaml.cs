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
using System.Windows.Navigation;
using Microsoft.Win32;

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для MyAccount.xaml
    /// </summary>
    public partial class MyAccount : UserControl
    {
        public static string toPhoto;
        public static User ThisUser;

        public MyAccount()
        {
            InitializeComponent();
        }

        public MyAccount(User user)
        {
            InitializeComponent();
            ThisUser = user;

            if (user.Photo != null)
            {
                UserPicture.Source = new BitmapImage(new Uri(@user.Photo));
            }
            UserNameTitle.Text = user.Username;
            UserNameReal.Text = user.Name;
            UserSurnameReal.Text = user.Surname;
            UserAbout.Text = user.User_About; 
        }

        private void UserPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "D:\\Лабы\\курсач\\WorldOfBook\\WorldOfBook\\Images\\Users\\";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (openFileDialog1.ShowDialog() == true)
                {
                    toPhoto = openFileDialog1.FileName;

                    using (User_Context bookdb = new User_Context())
                    {
                        MainWindow.CurrentUser.Photo = toPhoto;
                        var bdb = bookdb.UserContext;
                        for (int i = 0; i < bdb.Count(); i++)
                        {
                            if (MainWindow.CurrentUserId == bdb.AsEnumerable().ElementAt(i).Id)
                            {
                                bdb.AsEnumerable().ElementAt(i).Photo = toPhoto;
                            }
                        }
                        bookdb.SaveChanges();
                    }

                    UserPicture.Source = new BitmapImage(new Uri(toPhoto));
                }
            }
            catch
            {
                MessageBox.Show("Invalid data");
            }
        }

        //изменение личных данных
        public void Edit_button_click(object sender, RoutedEventArgs e)
        {
            User user;
            user = ThisUser;

            user.Surname = EditUserSurnameReal.Text;
            user.Name = EditUserNameReal.Text;
            user.User_About = UserAbout.Text;
            using (User_Context bookdb = new User_Context())
            {
                try
                {
                    MainWindow.CurrentUser.Name = EditUserNameReal.Text;
                    MainWindow.CurrentUser.Surname = EditUserSurnameReal.Text;
                    MainWindow.CurrentUser.User_About = UserAbout.Text;
                    var bdb = bookdb.UserContext;
                    for (int i = 0; i < bdb.Count(); i++)
                    {
                        if (MainWindow.CurrentUserId == bdb.AsEnumerable().ElementAt(i).Id)
                        {
                            if (EditUserNameReal.Text != "")
                                bdb.AsEnumerable().ElementAt(i).Name = EditUserNameReal.Text;
                            if (EditUserSurnameReal.Text != "")
                                bdb.AsEnumerable().ElementAt(i).Surname = EditUserSurnameReal.Text;
                            if (UserAbout.Text != "")
                                bdb.AsEnumerable().ElementAt(i).User_About = UserAbout.Text;
                        }
                    }
                    bookdb.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Invalid data");
                }
                
                
            }
        }
    }
}

