using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfBook
{
    public class Author
    {
        
        
        public int Id { get; set; }

        [RegularExpression(@"^([A-Z]{1}[a-z]{1,23})$")]
        public string Author_Name { get; set; }

        [RegularExpression(@"^([A-Z]{1}[a-z]{1,23})$")]
        public string Author_Surname { get; set; }

        [RegularExpression(@"^[1-2]{1}[0-9]{3}$")]
        public string Author_Birth { get; set; }

        [RegularExpression(@"^[1-2]{1}[0-9]{3}$")]
        public string Author_Die { get; set; }

        [RegularExpression(@"^([A-Za-z0-9\s\.\,\;\-\@]{1,300})$")]
        public string Author_Biography { get; set; }
        public string Picture { get; set; }

        public Author()
        {

        }

        

        public Author(int _Author_Id, string _Author_Name, string _Author_Surname, string _Author_Birth, string _Author_Die, string _Author_Biography, string _Picture)
        {
            Id = _Author_Id;
            Author_Name = _Author_Name;
            Author_Surname = _Author_Surname;
            Author_Birth = _Author_Birth;
            Author_Die = _Author_Die;
            Author_Biography = _Author_Biography;
            Picture = _Picture;
        }
    }
}
