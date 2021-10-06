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
using WorldOfBook.Properties;

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для ReadyToRead.xaml
    /// </summary>
    public partial class ReadyToRead : UserControl
    {
        public static Book NowReadBook;

        public ReadyToRead()
        {
            InitializeComponent();
        }

        public ReadyToRead(Book book)
        {
            InitializeComponent();
            NowReadBook = book;
            BookTitle.Text = book.BookName;

            foreach (Book books in MyBooks.bookList)
            {
                foreach (Author author in MyBooks.authorList)
                {
                    foreach (Genre genre in MyBooks.genreList)
                    {
                        if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                        {
                            Author.Text = author.Author_Surname;
                            Genre.Text = genre.Genre_Name;
                        }
                    }

                }
            }

            
            Year.Text = Convert.ToString(book.Year);
            Desc.Text = book.Description;
            Country.Text = book.Country;
            Picture.Source = new BitmapImage(new Uri(book.Picture));

        }

        private void BackToMy_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)App.Current.MainWindow;
            main.ContentGrid.Children.Clear();
            main.ContentGrid.Children.Add(new MyBooks());
        }

        private void ReadNow_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                PDFReader reader = new PDFReader(NowReadBook.Book_Text);
                MainWindow main = (MainWindow)App.Current.MainWindow;
                main.ContentGrid.Children.Clear();
                main.ContentGrid.Children.Add(reader);
            }
            catch
            {
                MessageBox.Show("Book has not been added yet");
            }
        }

        

        private void DeleteFromMyBookBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MyBooks.userBooksList.Count; i++)
            {
                if (NowReadBook.Id == MyBooks.userBooksList[i].Book_Id && MainWindow.CurrentUserId == MyBooks.userBooksList[i].User_Id)
                {

                    using (UserBooks_Context userdb = new UserBooks_Context())
                    {
                        var db = userdb.UserBooksContext;
                        db.Remove(db.AsEnumerable().ElementAt(i));
                        userdb.SaveChanges();
                    }

                    MyBooks.userBooksList.RemoveAt(i);
                }
            }
        }
    }
}
