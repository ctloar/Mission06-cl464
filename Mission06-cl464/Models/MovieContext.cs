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
        public DbSet<Category> Categories { get; set; }

        // Seeds the database with the data below
        protected override void OnModelCreating(ModelBuilder mb)
        {
            // Data for category table
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Adventure"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Action"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Horror"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Fantasy"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Romance"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Documentary"
                }
            );

            // Data for movie/responses table
            mb.Entity<MovieForm>().HasData(

                new MovieForm
                {
                    MovieId = 1,
                    CategoryId = 1,
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
                    CategoryId = 1,
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
                    CategoryId = 1,
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
