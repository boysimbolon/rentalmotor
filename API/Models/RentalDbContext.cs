using Microsoft.EntityFrameworkCore;

namespace RentalMotorApp.Models
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options)
            : base(options)
        {
        }
        public DbSet<Motor> motor { get; set; }
        public DbSet<DataRental> datarental { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataRental>()
                .HasOne(d => d.Motor)
                .WithMany(m => m.DataRentals)
                .HasForeignKey(d => d.IdMotor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
