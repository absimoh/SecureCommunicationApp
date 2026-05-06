using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecureCommunicationApp.Data;
using SecureCommunicationApp.Models;

namespace SecureCommunicationApp.Controllers
{
    public class GroupMembersController : Controller
    {
        private readonly AppDbContext _context;

        public GroupMembersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var members = _context.GroupMembers
                .Include(g => g.User)
                .Include(g => g.ChatGroup)
                .ToList();

            return View(members);
        }

        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(_context.Users, "UserId", "FullName");
            ViewBag.ChatGroupId = new SelectList(_context.ChatGroups, "ChatGroupId", "GroupName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,ChatGroupId,Role")] GroupMember groupMember)
        {
            if (ModelState.IsValid)
            {
                groupMember.JoinedAt = DateTime.UtcNow;

                _context.GroupMembers.Add(groupMember);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.UserId = new SelectList(_context.Users, "UserId", "FullName", groupMember.UserId);
            ViewBag.ChatGroupId = new SelectList(_context.ChatGroups, "ChatGroupId", "GroupName", groupMember.ChatGroupId);

            return View(groupMember);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var groupMember = _context.GroupMembers
                .Include(g => g.User)
                .Include(g => g.ChatGroup)
                .FirstOrDefault(g => g.GroupMemberId == id);

            if (groupMember == null)
                return NotFound();

            return View(groupMember);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var groupMember = _context.GroupMembers.Find(id);

            if (groupMember != null)
            {
                _context.GroupMembers.Remove(groupMember);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}