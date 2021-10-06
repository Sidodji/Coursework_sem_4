using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WorldOfBook
{
    class Book_Context : DbContext
    {
        public Book_Context()
            : base("DbConnect") //"DbConnection"
                                //: base("name=Books") //"DbConnection"
        {

        }

        public DbSet<Book> BookContext { get; set; }
    }
}
