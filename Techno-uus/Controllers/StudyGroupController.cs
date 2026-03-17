using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Techno_uus.Data;
using Techno_uus.Models;
using static Techno_uus.Models.StudyGroup;

namespace Techno_uus.Controllers
{
    public class StudyGroupController : Controller
    {
        private readonly SchoolContext _context;
        public StudyGroupController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudyGroups.ToListAsync());
        }
        // Siin on Create
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        // Siin on Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("Id,FirstName,LastName,GroupName,StudyStart,StudyEnd,LeaderPupilId,ClassroomInfo,Level")] StudyGroup 
            studyGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(("Index"));
            }
            return BadRequest();
        }
        //  Siin  on Details
        [HttpGet]
        public async Task<IActionResult>  Details (int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var studyGroup =await _context.StudyGroups
                 .FirstOrDefaultAsync(m => m.Id == id);
            if (studyGroup == null) 
            {
                return NotFound();
            }
            return View(studyGroup);
        }
        // Siin on Delete
        [HttpGet]
        public  async Task<IActionResult> Delete(int? id) 
        {
            if(id == null) 
            {
                return  NotFound(); 
            }
            var studyGroup  = await  _context.StudyGroups
                               .FirstOrDefaultAsync(m => m.Id == id);
            if (studyGroup == null) 
            {
                return NotFound();
            }
            return View(studyGroup);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  DeletePost(int id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var pupil =  await _context.StudyGroups.FindAsync(id);
            _context.StudyGroups.Remove(pupil);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Siin on Edit get
        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }

            var studyGroup = await _context.StudyGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyGroup == null)
            {
                return NotFound();
            }
            ViewBag.Pupils  = new SelectList(_context.Pupils, "Id", "FirstName");
            return  View("CreateEdit", studyGroup);
        }



    }
}
