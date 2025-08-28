using Microsoft.AspNetCore.Identity;
using Food_Reservation.Models;

namespace Food_Reservation.Helpers
{
    public static class PasswordHelper
    {
        public static bool VerifyPassword(string hashedPassword, string password)
        {
            var hasher = new PasswordHasher<Admin>();
            var result = hasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
