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
    /// Логика взаимодействия для BookElem.xaml
    /// </summary>
    public partial class BookElem : UserControl
    {
        public SolidColorBrush color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        public SolidColorBrush color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
        public string ReadyString = "";
        public static List<int> tempList = new List<int>();

        public BookElem()
        {
            InitializeComponent();
        }

        

        public BookElem(Book book)
        {
            InitializeComponent();
            BookName.Text = book.BookName;

            Author.Text = book.Author_Id.ToString();
            Genre.Text = book.Genre_Id.ToString();
            Year.Text = book.Year.ToString();
            Country.Text = book.Country;
            Description.Text = book.Description;
            PictureBox.Source = new BitmapImage(new Uri(@book.Picture));
        }

        public BookElem(Book book, string author, string genre)//
        {
            InitializeComponent();
            BookName.Text = book.BookName;
            Author.Text = author;
            Genre.Text = genre;
            Year.Text = book.Year.ToString();
            Country.Text = book.Country;
            Description.Text = book.Description;
            if (book.Picture != null)
            {
                PictureBox.Source = new BitmapImage(new Uri(@book.Picture));
            }
        }

        public BookElem(int Id, string _BookName, int _Year, int _Author, int User_Id, int Genre_Id, int Rating_Id, string _Country, string _Description, string Picture)
        {
            InitializeComponent();
            BookName.Text += _BookName;
            Author.Text += _Author;
            Genre.Text += Genre_Id;
            Year.Text += _Year;
            Country.Text += Country;
            Description.Text += Description;
            PictureBox.Source = new BitmapImage(new Uri(@Picture));
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.isMyBook)
            {
                using (UserBooks_Context userbooksdb = new UserBooks_Context())
                {
                    var ubdb = userbooksdb.UserBooksContext;
                    foreach (UserBooks userBooks in ubdb)
                    {
                        if (MainWindow.CurrentUserId == userBooks.User_Id)
                        {
                            tempList.Add(userBooks.Book_Id);
                        }
                    }
                }

                int index = MyBooks.wrapPanel.Children.IndexOf((UIElement)sender);
               

                using (Book_Context bookdb = new Book_Context())
                {
                    var bdb = bookdb.BookContext;
                    for (int j = 0; j < bdb.Count(); j++)
                    {
                        if (bdb.AsEnumerable().ElementAt(j).Id == tempList[index])
                        {
                            int id = MyBooks.bookList[j].Id;
                            string booktitle = MyBooks.bookList[j].BookName;
                            int auth = MyBooks.bookList[j].Author_Id;
                            int year = MyBooks.bookList[j].Year;
                            string country = MyBooks.bookList[j].Country;
                            string desc = MyBooks.bookList[j].Description;
                            int gen = MyBooks.bookList[j].Genre_Id;
                            string pic = MyBooks.bookList[j].Picture;
                            string btext = MyBooks.bookList[j].Book_Text;
                            Book elemX = new Book(id, booktitle, year, auth, gen, country, desc, pic, btext);

                            ReadyToRead readyToRead = new ReadyToRead(elemX);
                            MainWindow main = (MainWindow)App.Current.MainWindow;
                            main.ContentGrid.Children.Clear();
                            main.ContentGrid.Children.Add(readyToRead);
                        }

                    }
                }
                tempList.Clear();
            }
            else
            {
                int index = SearchBooks.wrapPanel.Children.IndexOf((UIElement)sender);

                int id = SearchBooks.bookList[index].Id;
                string booktitle = SearchBooks.bookList[index].BookName;
                int auth = SearchBooks.bookList[index].Author_Id;
                int year = SearchBooks.bookList[index].Year;
                string country = SearchBooks.bookList[index].Country;
                string desc = SearchBooks.bookList[index].Description;
                int gen = SearchBooks.bookList[index].Genre_Id;
                string pic = SearchBooks.bookList[index].Picture;
                string btext = SearchBooks.bookList[index].Book_Text;

                Book elemX = new Book(id, booktitle, year, auth, gen, country, desc, pic, btext);

                SelectedBook selectedBook = new SelectedBook(elemX);
                MainWindow main = (MainWindow)App.Current.MainWindow;
                main.ContentGrid.Children.Clear();
                main.ContentGrid.Children.Add(selectedBook);            }

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

