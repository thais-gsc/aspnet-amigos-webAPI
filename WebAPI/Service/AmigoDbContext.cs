using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class AmigoDbContext : IdentityDbContext<IdentityUser>
    {
        public AmigoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Amigo> amigo { get; set; }

        
    }
}
