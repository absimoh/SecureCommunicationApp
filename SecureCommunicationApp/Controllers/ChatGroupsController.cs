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
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GroupName,Description")] ChatGroup group)
        {
            if (ModelState.IsValid)
            {
                group.CreatedAt = DateTime.UtcNow;

                _context.ChatGroups.Add(group);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(group);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var group = _context.ChatGroups.Find(id);

            if (group == null)
                return NotFound();

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ChatGroupId,GroupName,Description,CreatedAt")] ChatGroup group)
        {
            if (id != group.ChatGroupId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.ChatGroups.Update(group);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(group);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var group = _context.ChatGroups
                .FirstOrDefault(g => g.ChatGroupId == id);

            if (group == null)
                return NotFound();

            return View(group);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var group = _context.ChatGroups
                .FirstOrDefault(g => g.ChatGroupId == id);

            if (group == null)
                return NotFound();

            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var group = _context.ChatGroups.Find(id);

            if (group != null)
            {
                _context.ChatGroups.Remove(group);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}