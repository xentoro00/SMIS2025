using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMIS2025.Data;
using SMIS2025.Models;

namespace SMIS2025.Controllers
{
    public class GradesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public GradesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Grades
        public async Task<IActionResult> Index()
        {

            // Fetch the list of users
            var users = await _userManager.Users.ToListAsync();
            Console.WriteLine("User ID: " + users);

            // Fetch grades with related data
            var grades = await _context.Grade
                .Include(g => g.Subject) // Include Subject details
                .ToListAsync();

            // Map StudentId to UserName dynamically
            foreach (var grade in grades)
            {
                var user = users.FirstOrDefault(u => u.Id == grade.StudentId);
                grade.StudentId = user?.UserName ?? "Unknown"; // Dynamically set the student's name
            }

            return View(grades);
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return NotFound();
            }

            // Fetch all grades for the logged-in student
            var grades = await _context.Grade
                .Include(g => g.Subject)
                .Where(m => m.StudentId == userId)
                .ToListAsync();

            if (grades == null || !grades.Any())
            {
                return NotFound();
            }

            // Return partial view with all grades
            return PartialView("_GradeDetails", grades);
        }


        // GET: Grades/Create
        public async Task<IActionResult> Create()
        {
            var numbers = new List<int> { 5, 6, 7, 8, 9, 10 };
            var gradeStatuses = new List<string> { "Normal", "Transfer" };
            var users = await _userManager.Users.ToListAsync();

            ViewData["Numbers"] = new SelectList(numbers);
            ViewData["GradeStatuses"] = new SelectList(gradeStatuses);

            ViewData["Users"] = new SelectList(users, "Id", "UserName");

            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name");

            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Letter,GradeStatus,StudentId,SubjectId")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", grade.SubjectId);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grade
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grade = await _context.Grade.FindAsync(id);
            if (grade != null)
            {
                _context.Grade.Remove(grade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _context.Grade.Any(e => e.Id == id);
        }
    }
}
