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
using System.Data;

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для BlockUsers.xaml
    /// </summary>
    public partial class UsersPage : UserControl
    {
        public static List<User> userList = new List<User>();
        public static WrapPanel wrapPanel;
        public static User currentUser;

        public UsersPage()
        {
            InitializeComponent();

        }

        public UsersPage(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            wrapPanel = UserPanel;
            MainWindow.isMyUser = true;

            userList.Clear();

            using (User_Context userdb = new User_Context())
            { 
                var udb = userdb.UserContext;
                foreach (User user in udb)
                {
                    if (user.Username != "Admin")
                    {
                        userList.Add(user);
                    }
                }
            }

            foreach (User user in userList)
            {
                if(user.Username!="Admin")
                {
                    UserElem elemX = new UserElem(user);
                    UserPanel.Children.Add(elemX);
                }
            }
        }
    }
}
