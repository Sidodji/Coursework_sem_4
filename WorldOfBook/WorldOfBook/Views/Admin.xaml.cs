using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddNewBookAdmin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }

        public static string path;
        public static string pathpict;

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewBookBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = new Book()
                { BookName = BookTitle.Text, Year = Convert.ToInt32(PubYear.Text), Author_Id = Convert.ToInt32(Author.Text), Genre_Id = Convert.ToInt32(Genre.Text), Country = PubCountry.Text, Description = Desc.Text, Picture = pathpict, Book_Text = PDF.Text };
                
                Book authBook = null;
                using (Book_Context bookdb = new Book_Context())
                {
                    authBook = bookdb.BookContext.Where(b => b.BookName == BookTitle.Text).FirstOrDefault();
                    if(authBook == null)
                    {
                        var bdb = bookdb.BookContext;
                        bdb.Add(book);
                        bookdb.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("This book has already been added");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid data. Try again");
            }
            
        }

        private void Desc_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BookTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            BookTitleBlock.Foreground = Brushes.Black;
        }

        private void Author_GotFocus(object sender, RoutedEventArgs e)
        {
            // AuthorBlock.Foreground = Brushes.Black;
        }

        private void Genre_GotFocus(object sender, RoutedEventArgs e)
        {
            GenreBlock.Foreground = Brushes.Black;
        }

        private void PubCountry_GotFocus(object sender, RoutedEventArgs e)
        {
            PubCountryBlock.Foreground = Brushes.Black;
        }

        private void PubYear_GotFocus(object sender, RoutedEventArgs e)
        {
            PubYearBlock.Foreground = Brushes.Black;
        }

        private void Disc_GotFocus(object sender, RoutedEventArgs e)
        {
            DescBlock.Foreground = Brushes.Black;
        }

        private void BookTitle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void AddAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            Admin1 admin1 = new Admin1();
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(admin1);
        }

        private void UsersPageBtn_Click(object sender, RoutedEventArgs e)
        {
            UsersPage usersPage = new UsersPage();
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(usersPage);
        }

        private void PDF_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string path = Pic.Text;
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "D:\\Лабы\\курсач\\WorldOfBook\\WorldOfBook\\Images\\";
                openFileDialog1.Filter = "Pdf Files|*.pdf";
                
                if (openFileDialog1.ShowDialog() == true)
                {
                    path = openFileDialog1.FileName;
                    PDF.Text = path;
                }
            }
            catch
            {
                MessageBox.Show("Invalid data");
                PDF.Clear();
            }
        }

        private void Pict_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "D:\\Лабы\\курсач\\WorldOfBook\\WorldOfBook\\Images\\";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (openFileDialog1.ShowDialog() == true)
                {
                    pathpict = openFileDialog1.FileName;
                    PictureBox.Source = new BitmapImage(new Uri(pathpict));
                }
            }
            catch
            {
                MessageBox.Show("Invalid data");
            }
        }
    }
}

