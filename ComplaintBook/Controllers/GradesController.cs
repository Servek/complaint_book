using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComplaintBook.Models.DataBase;
using Microsoft.AspNetCore.Authorization;

namespace ComplaintBook.Controllers
{
    [Authorize]
    public class GradesController : Controller
    {
        private readonly ApplicationContext _context;

        public GradesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Grades.Include(g => g.Employee);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (grade.Employee != null)
                grade.Employee.Post = await _context.Posts
                    .SingleOrDefaultAsync(m => m.Id == grade.Employee.PostId);

            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grades/Create
        [AllowAnonymous]
        public IActionResult CreateComplaint()
        {
            ViewData["EmployeeId"] = new SelectList((from s in _context.Employees
                                                     select new
                                                     {
                                                         Id = s.Id,
                                                         FullEmployee = s.Post.Name + " " + s.LastName + " " + s.Name
                                                     }),
                "Id",
                "FullEmployee");
            return View();
        }

        // GET: Grades/Create
        [AllowAnonymous]
        public IActionResult CreateSuggestion()
        {
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> CreateComplaint([Bind("Id,SenderName,SenderEmail,IsAccepted,Message,InternalReportType,Score,EmployeeId")] Grade grade)
        {
            grade.ReportType = ReportType.Complaint;
            if (ModelState.IsValid)
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList((from s in _context.Employees
                                                     select new
                                                     {
                                                         Id = s.Id,
                                                         FullEmployee = s.Post.Name + " " + s.LastName + " " + s.Name
                                                     }),
                "Id",
                "FullEmployee");
            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> CreateSuggestion([Bind("Id,SenderName,SenderEmail,IsAccepted,Message,InternalReportType,Score,EmployeeId")] Grade grade)
        {
            grade.ReportType = ReportType.Suggestion;
            if (ModelState.IsValid)
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grade);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades.SingleOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList((from s in _context.Employees
                                                     select new
                                                     {
                                                         Id = s.Id,
                                                         FullEmployee = s.Post.Name + " " + s.LastName + " " + s.Name
                                                     }),
                                                    "Id",
                                                    "FullEmployee",
                                                    grade.EmployeeId);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenderName,SenderEmail,IsAccepted,Message,InternalReportType,Score,EmployeeId")] Grade grade)
        {
            if (id != grade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList((from s in _context.Employees
                                                     select new
                                                     {
                                                         Id = s.Id,
                                                         FullEmployee = s.Post.Name + " " + s.LastName + " " + s.Name
                                                     }),
                                                    "Id",
                                                    "FullEmployee",
                                                    grade.EmployeeId);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
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
            var grade = await _context.Grades.SingleOrDefaultAsync(m => m.Id == id);
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.Id == id);
        }
    }
}
