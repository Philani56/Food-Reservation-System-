using Microsoft.EntityFrameworkCore;
using Food_Reservation.Models;

namespace Food_Reservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationItem> ReservationItems { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Reservation → ReservationItems (1-to-many)
            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.ReservationItems)
                .WithOne(ri => ri.Reservation)
                .HasForeignKey(ri => ri.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            // MenuItem → ReservationItems (1-to-many)
            modelBuilder.Entity<MenuItem>()
                .HasMany<ReservationItem>()
                .WithOne(ri => ri.MenuItem)
                .HasForeignKey(ri => ri.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}