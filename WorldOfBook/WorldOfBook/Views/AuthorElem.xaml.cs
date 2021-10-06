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

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для AuthorElem.xaml
    /// </summary>
    public partial class AuthorElem : UserControl
    {
        public SolidColorBrush color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        public SolidColorBrush color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));

        public AuthorElem()
        {
            InitializeComponent();
        }

        public AuthorElem(Author author)
        {
            InitializeComponent();

            SurName.Text = author.Author_Surname;
            Author.Text = author.Author_Name;
            Birth.Text = author.Author_Birth;
            Die.Text = author.Author_Die;
            Description.Text = author.Author_Biography;
            PictureBox.Source = new BitmapImage(new Uri(author.Picture));
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            background.Background = color2;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            background.Background = color1;
        }
    }
}

