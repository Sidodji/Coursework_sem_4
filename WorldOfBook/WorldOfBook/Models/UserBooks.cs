using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfBook
{
    public class UserBooks
    {
        public int Id { get; set; }
        
        public int User_Id { get; set; }
        
        public int Book_Id { get; set; }

        public UserBooks()
        {

        }

        public UserBooks(int _Id, int _User_Id, int _Book_Id)
        {
            this.Id = _Id;
            this.User_Id = _User_Id;
            this.Book_Id = _Book_Id;
        }
    }
}
