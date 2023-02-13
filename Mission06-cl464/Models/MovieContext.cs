using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_cl464.Models
{
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {
            // Leave blank for now
        }

        // Used to query and save instances of MovieForm
        public DbSet<MovieForm> responses { get; set; }

        // Seeds the database with the data below
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieForm>().HasData(

                new MovieForm
                {
                    MovieId = 1,
                    Category = "Adventure",
                    Title = "Fellowship of the Ring",
                    Year = 2001,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieForm
                {
                    MovieId = 2,
                    Category = "Adventure",
                    Title = "Two Towers",
                    Year = 2002,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "best series ever"
                },
                new MovieForm
                {
                    MovieId = 3,
                    Category = "Adventure",
                    Title = "Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
