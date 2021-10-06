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
    /// Логика взаимодействия для MyBooks.xaml
    /// </summary>
    public partial class MyBooks : UserControl
    {
        public static User currentUser;
        public static WrapPanel wrapPanel;
        public static List<Book> bookList = new List<Book>();
        public static List<UserBooks> userBooksList = new List<UserBooks>();
        public static List<Genre> genreList = new List<Genre>();
        public static List<Author> authorList = new List<Author>();

        public MyBooks()
        {
            InitializeComponent();
        }

        public MyBooks(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            wrapPanel = UserBooksPanel;
            MainWindow.isMyBook = true;

            bookList.Clear();
            authorList.Clear();
            genreList.Clear();
            userBooksList.Clear();


            using (Book_Context bookdb = new Book_Context())
            {
                var bdb = bookdb.BookContext;
                foreach (Book book in bdb)
                {
                    bookList.Add(book);
                }
            }

            using (Author_Context authorsdb = new Author_Context())
            {
                var adb = authorsdb.AuthorContext;
                foreach (Author author in adb)
                {
                    authorList.Add(author);
                }
            }

            using (Genre_Context genredb = new Genre_Context())
            {
                var gdb = genredb.GenreContext;
                foreach (Genre genre in gdb)
                {
                    genreList.Add(genre);
                }
            }

            using (UserBooks_Context userbooksdb = new UserBooks_Context())
            {
                var ubdb = userbooksdb.UserBooksContext;
                foreach (UserBooks userBooks in ubdb)
                {
                    userBooksList.Add(userBooks);
                }
            }

            foreach (Book book in bookList)
            {
                foreach (UserBooks userbooks in userBooksList)
                {
                    foreach (Author author in authorList)
                    {
                        foreach (Genre genre in genreList)
                        {
                            if (book.Author_Id == author.Id && book.Genre_Id == genre.Id && book.Id == userbooks.Book_Id && userbooks.User_Id == currentUser.Id)
                            {
                                BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                UserBooksPanel.Children.Add(elemX);
                            }
                        }
                    }
                }
            }
        }
    }
}
