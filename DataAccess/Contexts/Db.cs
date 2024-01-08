using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class Db:DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set;}
        public DbSet<Genre> Genre { get; set; }

        public Db(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>().HasKey(e => new {e.GenreId, e.MovieId});
        }
    }
}
