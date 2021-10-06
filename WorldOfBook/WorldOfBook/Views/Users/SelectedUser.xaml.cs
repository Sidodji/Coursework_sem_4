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
    /// Логика взаимодействия для SelectedUser.xaml
    /// </summary>
    public partial class SelectedUser : UserControl
    {
        public SelectedUser()
        {
            InitializeComponent();
        }

        public SelectedUser(User users)
        {
            InitializeComponent();

            currentUser = users;
            Username.Text = users.Username;
            Name.Text = users.Name;
            Surname.Text = users.Surname;
            Desc.Text = users.User_About;
            if (users.Photo != null)
            {
                Picture.Source = new BitmapImage(new Uri(@users.Photo));
            } 
        }

        public User currentUser { get; set; }

        public void Block_Unblock(object sender, RoutedEventArgs e)
        {

            using (User_Context userdb = new User_Context())
            {
                try
                {
                    var udb = userdb.UserContext.Where(item => item.Id == currentUser.Id).FirstOrDefault();
                    if(udb.Block_Id==0)
                    {
                        udb.Block_Id = 1;
                        MessageBox.Show("User banned");
                    }
                    else
                    {
                        udb.Block_Id = 0;
                        MessageBox.Show("User unbanned");
                    }
                    userdb.SaveChanges();
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"{exc.Message} {exc.InnerException}");
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(admin);
        }
    }
}
