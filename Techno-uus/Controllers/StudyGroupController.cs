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

    }
}
