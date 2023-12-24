
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PettaWebsite.DataContext
{
    public class PettaDbContext : IdentityDbContext
    {


        public PettaDbContext(DbContextOptions options) : base(options) { }
    }
}
