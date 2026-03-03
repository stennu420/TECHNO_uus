using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Techno_uus.Data;
using Techno_uus.Models;

namespace Techno_uus.Controllers
{
    public class PupilsController : Controller
    {
        private readonly SchoolContext _context;
        public PupilsController(SchoolContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult>Index()
        {
            return View(await _context.Pupils.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("FirstName,LastName,HasEnrolleddAt,DayOfBirth,PhoneNumber,PostCode,Grade")] Pupil
            juntsu)
        {
            if (ModelState.IsValid) 
            {
                _context.Pupils.Add(juntsu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
            {
                return NotFound();  
            }

            var pupil = await _context.Pupils
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pupil == null) 
            {
                return NotFound();
            }
            return View(pupil);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Pupils
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pupil == null)
            {
                return NotFound();
            }
            return View(pupil);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id) 
        {
            if (id == null) 
            {
                return BadRequest();
            }
            var pupil = await _context.Pupils.FindAsync(id);
            _context.Pupils.Remove(pupil);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
            {
                return BadRequest();
            }

            var pupil = await _context.Pupils
               .FirstOrDefaultAsync(m => m.Id == id);

            if (pupil == null)
            {
                return NotFound();
            }
            return View(pupil);

        }
        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id,[Bind
            ("FirstName,LastName,HasEnrolleddAt,DayOfBirth,PhoneNumber,PostCode,Grade")]Pupil
            juntsu) 
        {
            if (id == null) 
            {
                return BadRequest();
            }
            juntsu.Id = id;
            _context.Pupils.Update(juntsu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        


    }
}
