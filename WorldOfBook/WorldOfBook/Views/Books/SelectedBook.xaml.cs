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
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldOfBook.Properties;

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для SelectedBook.xaml
    /// </summary>
    public partial class SelectedBook : UserControl
    {
        public static Book CurrentBook;

        public SelectedBook(Book book, SearchBooks searchBooks)
        {
            InitializeComponent();

        }

        public SelectedBook(Book book)
        {
            InitializeComponent();
            CurrentBook = book;

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

            BookTitle.Text = book.BookName;
           
            Country.Text = book.Country;
            Year.Text = Convert.ToString(book.Year);
            Desc.Text = book.Description;
            PictureBox.Source = new BitmapImage(new Uri(book.Picture));

            foreach (UserBooks userbooks in MyBooks.userBooksList)
            {
                if (CurrentBook.Id == userbooks.Book_Id && userbooks.User_Id == MainWindow.CurrentUserId)
                {
                    AddToMyBookBtn.IsEnabled = false;
                }
            }
        }
        
        private void AddToMyBookBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                UserBooks userbook = new UserBooks()
                {
                    User_Id = MainWindow.CurrentUser.Id,
                    Book_Id = CurrentBook.Id
                };

                using (UserBooks_Context userdb = new UserBooks_Context())
                {
                    var db = userdb.UserBooksContext;
                    db.Add(userbook);
                    userdb.SaveChanges();
                }

                MessageBox.Show("Book was added");
            } catch { }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)App.Current.MainWindow;
            main.ContentGrid.Children.Clear();
            main.ContentGrid.Children.Add(new SearchBooks());
        }
    }
}
