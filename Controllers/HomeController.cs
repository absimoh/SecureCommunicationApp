using Microsoft.AspNetCore.Mvc;
using SecureCommunicationApp.Data;

namespace SecureCommunicationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.UsersCount = _context.Users.Count();
            ViewBag.MessagesCount = _context.Messages.Count();
            ViewBag.GroupsCount = _context.ChatGroups.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}