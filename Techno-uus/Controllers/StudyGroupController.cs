using Microsoft.AspNetCore.Mvc;
using static Techno_uus.Models.StudyGroup;

namespace Techno_uus.Controllers
{
    public class StudyGroupController : Controller
    {
        // Siin on Index 
      public async Task<IActionResult> Index()
      {
            var studyGroups = await _context.StudyGroups
                .Include(s => s.LeaderPupil)
                .OrderBy(s => s.Name)
                .ToListAsync();

            return View(studyGroups);

      } 
    }
}
