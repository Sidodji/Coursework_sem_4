using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfBook
{
    public class Genre
    {
        
        public int Id { get; set; }
        public string Genre_Name { get; set; }

        public Genre()
        {

        }

        

        public Genre(int _Genre_Id, string _Genre_Name)
        {
            this.Id = _Genre_Id;
            this.Genre_Name = _Genre_Name;
        }
    }
}
