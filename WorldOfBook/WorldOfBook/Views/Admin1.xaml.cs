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
    /// Логика взаимодействия для Admin1.xaml
    /// </summary>
    public partial class Admin1 : UserControl
    {
        

        public Admin1()
        {
            InitializeComponent();
        }

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PictureBox.Source = new BitmapImage(new Uri(Pic.Text));

                Author author = new Author()
                {
                    Author_Name = AuthName.Text,
                    Author_Surname = AuthorSurname.Text,
                    Author_Birth = Birth.Text,
                    Author_Die = Die.Text,
                    Author_Biography = Desc.Text,
                    Picture = Pic.Text
                };

                Author authName = null;
                Author authSurname = null;
                using (Author_Context userdb = new Author_Context())
                {
                    authName = userdb.AuthorContext.Where(b => b.Author_Name == AuthName.Text).FirstOrDefault();
                    authSurname = userdb.AuthorContext.Where(b => b.Author_Surname == AuthorSurname.Text).FirstOrDefault();
                    if(authName==null&&authSurname==null)
                    {
                        var udb = userdb.AuthorContext;
                        udb.Add(author);
                        userdb.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("This author has already been added");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid data. Please, try again");
            }
            finally
            {
                AuthName.Clear();
                AuthorSurname.Clear();
                Birth.Clear();
                Die.Clear();
                Desc.Clear(); 
            }
        }

       

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(admin);
        }

        private void AuthName_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Birth_PreviewTextInput(object sender, RoutedEventArgs e)
        {

        }


        private void Author_GotFocus(object sender, RoutedEventArgs e)
        {
            // AuthorBlock.Foreground = Brushes.Black;
        }

        private void Genre_GotFocus(object sender, RoutedEventArgs e)
        {
            // GenreBlock.Foreground = Brushes.Black;
        }

        private void PubCountry_GotFocus(object sender, RoutedEventArgs e)
        {
            // PubCountryBlock.Foreground = Brushes.Black;
        }

        private void PubYear_GotFocus(object sender, RoutedEventArgs e)
        {
            //PubYearBlock.Foreground = Brushes.Black;
        }

        private void Disc_GotFocus(object sender, RoutedEventArgs e)
        {
            DescBlock.Foreground = Brushes.Black;
        }

        private void AuthName_PreviewTextInput(object sender, RoutedEventArgs e)
        {
            //DescBlock.Foreground = Brushes.Black;
        }

        private void Desc_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BookTitle_PreviewTextInput(object sender, TextChangedEventArgs e)
        {

        }

        private void Pic_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
