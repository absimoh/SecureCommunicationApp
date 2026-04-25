using Microsoft.AspNetCore.Mvc;
using SecureCommunicationApp.Data;
using SecureCommunicationApp.Models;

namespace SecureCommunicationApp.Controllers
{
    public class ChatGroupsController : Controller
    {
        private readonly AppDbContext _context;

        public ChatGroupsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var groups = _context.ChatGroups.ToList();
            return View(groups);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChatGroup group)
        {
            _context.ChatGroups.Add(group);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}