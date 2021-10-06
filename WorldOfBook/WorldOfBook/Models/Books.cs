using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfBook
{
    public class Book
    {
        
        public int Id { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z\s]{1,20})$")]
        public string BookName { get; set; }

        [RegularExpression(@"^[1-2]{1}[0-9]{3}$")]
        public int Year { get; set; }
        
        
        public int Author_Id { get; set; }
        
        public int Genre_Id { get; set; }

        [RegularExpression(@"^([A-Z]{1}[a-z]{1,23})$")]
        public string Country { get; set; }

        [RegularExpression(@"^([A-Za-z0-9\s\.\,\;\-\@]{1,300})$")]
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Book_Text { get; set; }

        

        public Book()
        {

        }

        public Book(int _Book_Id, string _BookName, int _Year, int _Author_Id, int _Genre_Id, string _Country, string _Description, string _Picture, string _Book_Text)
        {
            this.Id = _Book_Id;
            this.BookName = _BookName;
            this.Year = _Year;
            this.Author_Id = _Author_Id;
            this.Genre_Id = _Genre_Id;
            this.Country = _Country;
            this.Description = _Description;
            this.Picture = _Picture;
            this.Book_Text = _Book_Text;
        }
    }
}
