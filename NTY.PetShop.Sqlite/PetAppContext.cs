using Microsoft.EntityFrameworkCore;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Sqlite.Entities;

namespace NTY.PetShop.Sqlite
{
    public class PetAppContext : DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>()
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<PetEntity>()
                .HasOne(p => p.Type)
                .WithMany()
                .HasForeignKey(p => p.PetTypeId);
            
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner);
        }

        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<InsuranceEntity> Insurances { get; set; }
    }
}