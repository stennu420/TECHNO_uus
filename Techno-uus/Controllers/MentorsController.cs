using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techno_uus.Data;
using Techno_uus.Models;

namespace Techno_uus.Controllers
{
    public class MentorsController : Controller
    {
        private readonly SchoolContext _context;
        public  MentorsController(SchoolContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mentors.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName,PersonalCode, PhoneNumber, Email, IsFired")] Mentor mentor)
        {
            if (ModelState.IsValid) 
            {
                _context.Add(mentor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
