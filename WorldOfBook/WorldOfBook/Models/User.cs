using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfBook
{
    public class User
    {
        
        public int Id { get; set; }

        [RegularExpression(@"^([A-Z]{1}[a-z]{1,23})$")]
        public string Name { get; set; }

        [RegularExpression(@"^([A-Z]{1}[a-z]{1,23})$")]
        public string Surname { get; set; }

        [RegularExpression(@"^([A-Za-z0-9]{1,23})$")]
        public string Username { get; set; }

        [RegularExpression(@"^([A-Za-z0-9\s\.\,\;\-\@]{1,300})$")]
        public string User_About { get; set; }

        public string Photo { get; set; }
        public string Password { get; set; }
        public int Block_Id { get; set; }



        public User()
        {

        }

        public User(int id,string name, string surname, string username, string user_about, string photo, string password, int block_id)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Username = username;
            this.User_About = user_about;
            this.Photo = photo;
            this.Password = password;
            this.Block_Id = block_id;
            
        }
    }
}
