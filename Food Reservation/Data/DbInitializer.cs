using Microsoft.AspNetCore.Identity;
using Food_Reservation.Models;
using Food_Reservation.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (!context.Admins.Any())
        {
            var hasher = new PasswordHasher<Admin>();

            var admin = new Admin
            {
                Username = "admin",
                // hash password before storing
                PasswordHash = hasher.HashPassword(null, "Admin123!")
            };

            context.Admins.Add(admin);
            context.SaveChanges();
        }
    }
}
