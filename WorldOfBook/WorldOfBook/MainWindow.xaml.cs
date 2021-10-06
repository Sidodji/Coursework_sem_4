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
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Media.Animation;
using WorldOfBook.Properties;
using System.Threading;
using System.Globalization;

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;

        public static User CurrentUser;
        public static Genre genre;
        public SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7E57C2"));
        public static int CurrentUserId;
        public static bool isMyBook = false;
        public static bool isMyUser = false;
        public static bool flag = false;

        public MainWindow()
        {
            InitializeComponent();

            if (CurrentUserId == 0)
            {
                First.IsEnabled = false;
                Second.IsEnabled = false;
                Third.IsEnabled = false;
            }

            using (User_Context userdb = new User_Context())
            {
                var db = userdb.UserContext;
                foreach (User user in db)
                {
                    if (user.Id == CurrentUserId)
                    {
                        CurrentUser = user;
                        if (user.Photo != null)
                        {
                            UserAcc.Source = new BitmapImage(new Uri(user.Photo));
                        }
                    }
                }
            }
        }


        public MainWindow(bool isAdmin)
        {
            InitializeComponent();

            if (isAdmin)
            {
                admin.Visibility = Visibility.Visible;
                First.IsEnabled = false;
                Second.IsEnabled = false;
            }
            else
            {
                admin.Visibility = Visibility.Collapsed;
            }
        }

        private void OpenMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Collapsed;
            CloseMenuButton.Visibility = UserInfo.Visibility = Visibility.Visible;
        }

        private void CloseMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Visible;
            CloseMenuButton.Visibility = UserInfo.Visibility = Visibility.Collapsed;
        }

        
        public void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            try
            {
                this.DragMove();
            }
            catch {
                Console.WriteLine("An exception was thrown");
            }
        }


        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Close();
        }



        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MenuListView.SelectedIndex = -1;
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new SettingsWindow());
        }

        private void MenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = MenuListView.SelectedIndex;
            if (index == -1) return;
            if (GridMenu.Width != 60)
            {
                OpenMenuButton.Visibility = Visibility.Visible;
                UserInfo.Visibility = CloseMenuButton.Visibility = Visibility.Collapsed;
                DoubleAnimation buttonAnimation = new DoubleAnimation
                {
                    From = GridMenu.ActualWidth,
                    To = 60,
                    Duration = TimeSpan.FromSeconds(0.2),
                    FillBehavior = FillBehavior.Stop
                };
                GridMenu.BeginAnimation(Button.WidthProperty, buttonAnimation);
                Storyboard sb = new Storyboard();
                ThicknessAnimation commGridAnimation = new ThicknessAnimation
                {
                    From = new Thickness(200, 0, 0, 0),
                    To = new Thickness(0, 0, 0, 0),
                    FillBehavior = FillBehavior.Stop,
                    Duration = TimeSpan.FromSeconds(0.3)
                };
                Storyboard.SetTarget(commGridAnimation, ContentGrid);
                Storyboard.SetTargetProperty(commGridAnimation, new PropertyPath(MarginProperty));
                sb.Children.Add(commGridAnimation);
                sb.Begin();
            }
            switch (index)
            {
                case 0:
                    ContentGrid.Children.Clear();
                    //
                    ContentGrid.Children.Add(new MyAccount(CurrentUser));
                    break;
                case 1:
                    MyBooks myBooks = new MyBooks(CurrentUser);
                    ContentGrid.Children.Clear();
                    ProgressBar1.Visibility = Visibility.Visible;
                    ContentGrid.Children.Add(myBooks);
                    break;
                case 2:
                    SearchBooks searchBooks = new SearchBooks();
                    ProgressBar1.Visibility = Visibility.Visible;
                    ProgressBar1.Visibility = Visibility.Collapsed;
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(searchBooks);
                    break;
                case 3:
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new Admin());
                    break;
            }
        }

        private void CloseButt_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Loaded_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = this;
        }
    }
}
