using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WorldOfBook
{
    class UserBooks_Context : DbContext
    {
        public UserBooks_Context()
            : base("DbConnect") //"DbConnection"
                                //: base("name=Books") //"DbConnection"
        {

        }

        public DbSet<UserBooks> UserBooksContext { get; set; }
    }
}
