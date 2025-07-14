using AppAmostras.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppAmostras.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Amostra> Amostras { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
           
            modelBuilder.Entity<Amostra>()
                .HasOne(p => p.Status)
                .WithMany(b => b.Amostras)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasForeignKey(p => p.StatusId);
        }
    }
}
