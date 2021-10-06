using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WorldOfBook
{
    class Author_Context : DbContext
    {
        public Author_Context()
            : base("DbConnect") //"DbConnection"
                                //: base("name=Books") //"DbConnection"
        {

        }

        public DbSet<Author> AuthorContext { get; set; }
    }
}
