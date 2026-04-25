using Microsoft.AspNetCore.Mvc;
using SecureCommunicationApp.Data;
using SecureCommunicationApp.Models;

namespace SecureCommunicationApp.Controllers
{
    public class MessagesController : Controller
    {
        private readonly AppDbContext _context;

        public MessagesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var messages = _context.Messages.ToList();
            return View(messages);
        }

        public IActionResult Create()
        {
            ViewBag.Users = _context.Users.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Message message)
        {
            message.SentDate = DateTime.Now;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}