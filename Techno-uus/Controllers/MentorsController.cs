using Microsoft.AspNetCore.Mvc;
<<<<<<< Updated upstream
using Microsoft.EntityFrameworkCore;
using Techno_uus.Data;
using Techno_uus.Models;
=======
using Techno_uus.Data;
>>>>>>> Stashed changes

namespace Techno_uus.Controllers
{
    public class MentorController : Controller
    {
        private readonly SchoolContext _context;
<<<<<<< Updated upstream
        public  MentorController(SchoolContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mentors.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create() 
=======

        public MentorsController(SchoolContext context)
        {
            context = _context;
        }
        public IActionResult Index()
>>>>>>> Stashed changes
        {
            return View();
        }

<<<<<<< Updated upstream
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName,PersonalCode, PhoneNumber, Email, IsFired")] Mentor mentor)
        {
            if (ModelState.IsValid) 
            {
                _context.Add(mentor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mentor);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }

            var mentor = await _context.Mentors
               .FirstOrDefaultAsync(mentor => mentor .Id == id);


            if (mentor == null)
            {
                return NotFound();
            }
            return View(mentor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            if(id == null) 
            {
                return NotFound();
            }

            var mentor = await _context.Mentors.FindAsync(id);

            if(mentor == null) 
            {
                return NotFound();
            }
            return View(mentor);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Mentor mentor) 
        {
            if (ModelState.IsValid) 
            {
                _context.Update(mentor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mentor);
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var mentor = await _context.Mentors
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mentor == null) 
            {
                return NotFound();
            } 
            return View(mentor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id) 
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Mentors = await _context.Mentors.FindAsync(id);
            _context.Mentors.Remove(Mentors);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

=======
        public IActionResult
>>>>>>> Stashed changes
    }
}
