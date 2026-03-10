using Microsoft.AspNetCore.Mvc;
using Techno_uus.Data;
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
            _context = context;
      }
        // Siin on Create
        [HttpGet]
        public IActionResult Cretae()
        {
            ViewBag.LeaderPupilId = new SelectList(_context.Pupils, "Id", "FirstName");
            return View("CreateEdit");
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,GroupName,StudyStart,StudyEnd,LeaderPupilId,ClassroomInfo,Level")] StudyGroup studyGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.LeaderPupilId = new SelectList(_context.Pupils, "Id", "FirstName", studyGroup.LeaderPupilId);
            return View("CreateEdit", studyGroup);
        }
        

    }
}
