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
        // Siin on Index 
      public async Task<IActionResult> Index()
      {
            var studyGroups = await _context.StudyGroup
           .Include(s => s.LeaderPupil)
           .ToListAsync();

            return View(studyGroups);
        } 

      private readonly SchoolContext _context;
      public StudyGroupController(SchoolContext context)
      {
        private readonly SchoolContext _context;
        public StudyGroupController(SchoolContext context)
        {
            _context = context;
      }
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudyGroups.ToListAsync());
        }

        // Siin on Create
        [HttpGet]
        public IActionResult Cretae()

        public IActionResult Create()
        {
            ViewBag.LeaderPupilId = new SelectList(_context.Pupils, "Id", "FirstName");
            return View("CreateEdit");
            return View();
        }

        // Siin on Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,GroupName,StudyStart,StudyEnd,LeaderPupilId,ClassroomInfo,Level")] StudyGroup studyGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                return RedirectToAction(("Index"));
            }
            ViewBag.LeaderPupilId = new SelectList(_context.Pupils, "Id", "FirstName", studyGroup.LeaderPupilId);
            return View("CreateEdit", studyGroup);
            return BadRequest();
        }
        

    }
}
