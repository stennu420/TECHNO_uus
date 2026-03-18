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
            ViewData["Värv"] = "Create";
            ViewData["LeaderPupilId"] = new SelectList(_context.Pupils, "PupilId", "FirstName");
            return View("CreateEdit");
        }
    
      
        // Siin on Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("StudyGroupId,GroupName,StudyStart,StudyEnd,LeaderPupilId,ClassroomInfo,Level")] StudyGroup 
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
                 .FirstOrDefaultAsync(m => m.StudyGroupId == id);
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
                              .FirstOrDefaultAsync (m => m.StudyGroupId == id);
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
                .FirstOrDefaultAsync(m => m.StudyGroupId == id);
            if (studyGroup == null)
            {
                return NotFound();
            }

            ViewData["Värv"] = "Edit";
            ViewData["LeaderPupilId"] = new SelectList(_context.Pupils, "PupilId", "FirstName");
            return View("CreateEdit");
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id, [Bind
            ("StudyGroupId,GroupName,StudyStart,StudyEnd,LeaderPupilId,ClassroomInfo,Level")] StudyGroup
            studyGroup)
        {
            if(id == null) 
            {
                return BadRequest();
            }
            studyGroup.StudyGroupId = id;
            _context.StudyGroups.Update(studyGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index" );
        }



    }
}
