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

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для UserElem.xaml
    /// </summary>

    public partial class UserElem : UserControl
    {
       
        public static List<int> tempList = new List<int>();
        public UserElem()
        {
            InitializeComponent();
        }

        public UserElem(User user)
        {
            InitializeComponent();
            
            Username.Text = user.Username;
            UserSurname.Text = user.Surname;
            User_Name.Text = user.Name;
            if (user.Photo != null)
            {
                PictureBox.Source = new BitmapImage(new Uri(@user.Photo));
            }
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            int index = UsersPage.wrapPanel.Children.IndexOf((UIElement)sender);
            int id = UsersPage.userList[index].Id;
            int userId = UsersPage.userList[index].Id;
            string userName = UsersPage.userList[index].Name;
            string userSurname = UsersPage.userList[index].Surname;
            string userUsername = UsersPage.userList[index].Username;
            string userAbout = UsersPage.userList[index].User_About;
            string userPhoto = UsersPage.userList[index].Photo;
            string userPassword = UsersPage.userList[index].Password;
            int userBlock = UsersPage.userList[index].Block_Id;
            
            User elemX = new User(id ,userName, userUsername, userUsername, userAbout, userPhoto, userPassword, userBlock);
            SelectedUser selectedUser = new SelectedUser(elemX);
            try
            {
                MainWindow main = (MainWindow)App.Current.MainWindow;

                main.ContentGrid.Children.Clear();
                main.ContentGrid.Children.Add(selectedUser);
            }
            catch(Exception exc)
            {
                MessageBox.Show($"{exc.Message}");
            }    
        }
    }
}
