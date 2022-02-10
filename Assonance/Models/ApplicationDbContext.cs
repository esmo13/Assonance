using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assonance.Models;

namespace Assonance.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.EnableSensitiveDataLogging();
            
        }
        public DbSet<Assonance.Models.User> User_ { get; set; }
        public DbSet<Assonance.Models.Song> Song { get; set; }
        
        public DbSet<Assonance.Models.Rating_> Rating_ { get; set; }
        public DbSet<Assonance.Models.Artist> Artist { get; set; }
        public DbSet<Assonance.Models.Genre> Genre { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Assonance.Models.Album> Album { get; set; }
        public DbSet<Assonance.Models.Comment> Comment { get; set; }
    }
}
