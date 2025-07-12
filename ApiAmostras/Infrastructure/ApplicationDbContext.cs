using ApiAmostras.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ApiAmostras.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Amostra> Amostras { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;
    }
}
