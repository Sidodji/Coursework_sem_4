using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WorldOfBook
{
    class Genre_Context : DbContext
    {
        public Genre_Context()
            : base("DbConnect") //"DbConnection"
                                //: base("name=Books") //"DbConnection"
        {
            Database.SetInitializer(new DBInitializar());
        }

        public DbSet<Genre> GenreContext { get; set; }
    }
}
