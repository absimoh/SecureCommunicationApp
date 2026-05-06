using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var messages = _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToList();

            return View(messages);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var message = _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .FirstOrDefault(m => m.MessageId == id);

            if (message == null)
                return NotFound();

            return View(message);
        }

        public IActionResult Create()
        {
            ViewBag.SenderId = new SelectList(_context.Users, "UserId", "FullName");
            ViewBag.ReceiverId = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Content,SenderId,ReceiverId,IsRead")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.SentDate = DateTime.UtcNow;

                _context.Messages.Add(message);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.SenderId = new SelectList(_context.Users, "UserId", "FullName", message.SenderId);
            ViewBag.ReceiverId = new SelectList(_context.Users, "UserId", "FullName", message.ReceiverId);

            return View(message);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var message = _context.Messages.Find(id);

            if (message == null)
                return NotFound();

            ViewBag.SenderId = new SelectList(_context.Users, "UserId", "FullName", message.SenderId);
            ViewBag.ReceiverId = new SelectList(_context.Users, "UserId", "FullName", message.ReceiverId);

            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MessageId,Content,SentDate,IsRead,SenderId,ReceiverId")] Message message)
        {
            if (id != message.MessageId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(message);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.SenderId = new SelectList(_context.Users, "UserId", "FullName", message.SenderId);
            ViewBag.ReceiverId = new SelectList(_context.Users, "UserId", "FullName", message.ReceiverId);

            return View(message);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var message = _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .FirstOrDefault(m => m.MessageId == id);

            if (message == null)
                return NotFound();

            return View(message);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var message = _context.Messages.Find(id);

            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}