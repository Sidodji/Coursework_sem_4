using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfBook
{
    class DBInitializar : CreateDatabaseIfNotExists<Genre_Context>
    {
        protected override void Seed(Genre_Context genre_Context)
        {
            var genre1 = new Genre(1, "Adventure");
            var genre2 = new Genre(2, "Roman");
            var genre3 = new Genre(3, "Horror");
            var genre4 = new Genre(4, "Love");
            var genre5 = new Genre(5, "Fantasy");

            var genres = new List<Genre>();
            genres.Add(genre1);
            genres.Add(genre2);
            genres.Add(genre3);
            genres.Add(genre4);
            genres.Add(genre5);
            genres.ForEach(t => genre_Context.GenreContext.Add(t));
            genre_Context.SaveChanges();
        }
    }
}
