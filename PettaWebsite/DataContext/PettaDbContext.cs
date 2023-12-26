
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PettaWebsite.Models;

namespace PettaWebsite.DataContext
{
    public class PettaDbContext : IdentityDbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Horse> Horses { get; set; }

        public PettaDbContext(DbContextOptions options) : base(options) { }
    }
}
