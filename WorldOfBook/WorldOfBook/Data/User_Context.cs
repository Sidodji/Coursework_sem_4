using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WorldOfBook
{
    class User_Context : DbContext
    {
        public User_Context()
            : base("DbConnect") //"DbConnection"
                                //: base("name=Books") //"DbConnection"
        {
            
        }

        public DbSet<User> UserContext { get; set; }
    }
}
