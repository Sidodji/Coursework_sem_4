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
using System.Windows.Navigation;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Media.Animation;
using System.Collections;

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для SearchBooks.xaml
    /// </summary>
    public partial class SearchBooks : UserControl
    {
        public static int SearchSelIndBack;
        public static string SearchTextBack;
        public static WrapPanel wrapPanel;
        public static List<Book> bookList = new List<Book>();
        public static List<User> userList = new List<User>();
        public static List<Genre> genreList = new List<Genre>();
        public static List<Author> authorList = new List<Author>();

        public SearchBooks()
        {
            InitializeComponent();

        }

        //public SearchBooks(Genre genre)
        //{
        //    InitializeComponent();
        //}

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            ScrollView.LineUp();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            ScrollView.LineDown();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            if (SearchTextBox.Text != "")
            {
                Book WorldOfBook = new Book();

                ThicknessAnimation anim1 = new ThicknessAnimation();
                anim1.From = new Thickness(0, 10, 0, 0);
                anim1.To = new Thickness(0, 30, 0, 0);
                anim1.FillBehavior = FillBehavior.Stop;
                anim1.Duration = new Duration(TimeSpan.FromSeconds(0.25));
                ScrollView.BeginAnimation(Label.MarginProperty, anim1);

                SearchSelIndBack = SearchCombo.SelectedIndex;
                SearchTextBack = SearchTextBox.Text.ToLower();
                int selected_index = SearchCombo.SelectedIndex;
                switch (selected_index)
                {
                    case 0:
                        ListBookWrapPanel.Children.Clear();

                        var BookName = (from n in bookList
                                        where n.BookName.ToLower().StartsWith(SearchTextBox.Text.ToLower())
                                        select n).ToList();
                        foreach (Book book in BookName)
                        {
                            foreach (Author author in authorList)
                            {
                                foreach (Genre genre in genreList)
                                {
                                    if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                    {
                                        BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                        ListBookWrapPanel.Children.Add(elemX);
                                    }
                                }
                            }
                        }
                        break;
                    case 1:
                        ListBookWrapPanel.Children.Clear();
                        var AuthorName = (from n in authorList
                                          where n.Author_Name.ToLower().StartsWith(SearchTextBox.Text.ToLower())
                                          select n).ToList();
                        foreach (Book book in bookList)
                        {
                            foreach (Author author in AuthorName)
                            {
                                foreach (Genre genre in genreList)
                                {
                                    if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                    {
                                        BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                        ListBookWrapPanel.Children.Add(elemX);
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        ListBookWrapPanel.Children.Clear();
                        var PubCountry = (from n in bookList
                                          where n.Country.ToLower().StartsWith(SearchTextBox.Text.ToLower())
                                          select n).ToList();
                        foreach (Book book in PubCountry)
                        {
                            foreach (Author author in authorList)
                            {
                                foreach (Genre genre in genreList)
                                {
                                    if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                    {
                                        BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                        ListBookWrapPanel.Children.Add(elemX);
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        ListBookWrapPanel.Children.Clear();
                        int outyear;
                        bool result = Int32.TryParse(SearchTextBox.Text, out outyear);
                        if (result)
                        {
                            var PubYear = (from n in bookList
                                           where n.Year == outyear
                                           select n).ToList();
                            foreach (Book book in PubYear)
                            {
                                foreach (Author author in authorList)
                                {
                                    foreach (Genre genre in genreList)
                                    {
                                        if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                        {
                                            BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                            ListBookWrapPanel.Children.Add(elemX);
                                        }
                                    }
                                }
                            }
                        }
                        else Icon1.Foreground = Brushes.Red;
                        break;
                    case 4:
                        ListBookWrapPanel.Children.Clear();

                        var Genre = (from n in genreList
                                     where n.Genre_Name.ToLower().StartsWith(SearchTextBox.Text.ToLower())
                                     select n).ToList();
                        foreach (Genre genre in Genre)
                        {
                            foreach (Author author in authorList)
                            {
                                foreach (Book book in bookList)
                                {
                                    if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                    {
                                        BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                        ListBookWrapPanel.Children.Add(elemX);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                Icon1.Foreground = Brushes.Red;
            }
            wrapPanel = ListBookWrapPanel;
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            int index = SearchCombo.SelectedIndex;
            ListBookWrapPanel.Children.Clear();

            switch (index)
            {
                case 0:

                    foreach (Book book in bookList)
                    {
                        foreach (Author author in authorList)
                        {
                            foreach (Genre genre in genreList)
                            {
                                if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                {
                                    BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                    ListBookWrapPanel.Children.Add(elemX);
                                }
                            }
                        }
                    }
                    break;
                case 1:
                    ListBookWrapPanel.Children.Clear();
                    authorList = authorList.OrderBy(x => x.Author_Name).ToList();
                    foreach (Author author in authorList)
                    {
                        List<BookElem> bookElems = new List<BookElem>();
                        foreach (Book book in bookList)
                        {
                            foreach (Genre genre in genreList)
                            {
                                if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                {
                                    BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                    ListBookWrapPanel.Children.Add(elemX);
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    ListBookWrapPanel.Children.Clear();

                    bookList = bookList.OrderBy(x => x.Country).ToList();
                    foreach (Book book in bookList)
                    {
                        foreach (Author author in authorList)
                        {
                            foreach (Genre genre in genreList)
                            {
                                if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                {
                                    BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                    ListBookWrapPanel.Children.Add(elemX);
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    ListBookWrapPanel.Children.Clear();

                    bookList = bookList.OrderBy(x => x.Year).ToList();
                    foreach (Book book in bookList)
                    {
                        foreach (Author author in authorList)
                        {
                            foreach (Genre genre in genreList)
                            {
                                if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                {
                                    BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                    ListBookWrapPanel.Children.Add(elemX);
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    ListBookWrapPanel.Children.Clear();

                    genreList = genreList.OrderBy(x => x.Genre_Name).ToList();
                    foreach (Genre genre in genreList)
                    {
                        foreach (Author author in authorList)
                        {
                            foreach (Book book in bookList)
                            {
                                if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                                {
                                    BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                                    ListBookWrapPanel.Children.Add(elemX);
                                }
                            }
                        }
                    }
                    break;
            }
            wrapPanel = ListBookWrapPanel;
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //Icon1.Foreground = color;
        }

        private void ViewAll_Click(object sender, RoutedEventArgs e)
        {
            ListBookWrapPanel.Children.Clear();
            bookList = bookList.OrderBy(x => x.BookName).ToList();
            foreach (Book book in bookList)
            {
                foreach (Author author in authorList)
                {
                    foreach (Genre genre in genreList)
                    {
                        if (book.Author_Id == author.Id && book.Genre_Id == genre.Id)
                        {
                            BookElem elemX = new BookElem(book, author.Author_Name, genre.Genre_Name);
                            ListBookWrapPanel.Children.Add(elemX);

                        }
                    }
                }
            }
            wrapPanel = ListBookWrapPanel;


        }

        private void Coll_Click(object sender, RoutedEventArgs e)
        {
            ListBookWrapPanel.Children.Clear();
            //List<Author> authorList1 = new List<Author>();
            //using (Author_Context authorsdb = new Author_Context())
            //{
            //    var adb = authorsdb.AuthorContext;
            //    foreach (Author author in adb)
            //    {
            //        authorList1.Add(author);
            //    }
            //}
            foreach (Author author in authorList)
            {
                AuthorElem elemX = new AuthorElem(author);
                ListBookWrapPanel.Children.Add(elemX);

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.isMyBook = false;

            bookList.Clear();
            authorList.Clear();
            genreList.Clear();
            userList.Clear();

            using (Book_Context booksdb = new Book_Context())
            {
                var db = booksdb.BookContext;
                foreach (Book book in db)
                {
                    bookList.Add(book);
                }
            }
            using (User_Context usersdb = new User_Context())
            {
                var db = usersdb.UserContext;
                foreach (User user in db)
                {
                    userList.Add(user);
                }
            }
            using (Genre_Context genresdb = new Genre_Context())
            {
                var db = genresdb.GenreContext;
                foreach (Genre genre in db)
                {
                    genreList.Add(genre);
                }
            }
            using (Author_Context authordb = new Author_Context())
            {
                var db = authordb.AuthorContext;
                foreach (Author author in db)
                {
                    authorList.Add(author);
                }
            }
        }
    }
}
