using Food_Reservation.Data;
using Food_Reservation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Food_Reservation.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin Login Page
        public IActionResult Login()
        {
            return View();
        }

        // POST: Handle Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _context.Admins
                                .FirstOrDefault(a => a.Username == username && a.PasswordHash == password);

            if (admin != null)
            {
                // Login successful
                HttpContext.Session.SetString("AdminUser", admin.Username);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Username or Password!";
            return View();
        }

        // GET: Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("AdminUser") == null)
                return RedirectToAction("Login");

            ViewBag.Username = HttpContext.Session.GetString("AdminUser");
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminUser");
            return RedirectToAction("Login");
        }
    }
}
