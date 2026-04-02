using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Techno_uus.Data;
using Techno_uus.Models;

namespace Techno_uus.Controllers
{
    public class SportGamesController : Controller
    {
        private readonly SchoolContext _context;

        public SportGamesController(SchoolContext context) 
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index() 
        {
           return View(await _context.SportGames.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create() 
        {   
           ViewData["Värv"] = "Create";
           ViewData["FirstTeamName"] = new SelectList(_context.SportGames, "GameId", "FirstTeamName");
           return View("CreateEdit");
        }

        [HttpPost]
        public async Task<IActionResult> Create(SportGames Game) 
        {
            if (ModelState.IsValid) 
            {
                _context.Add(Game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Game);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(int? id) 
        {
          if (id == null) 
          {
              return NotFound();
          }
          
               
          ViewData["Värv"] = "Edit";
            ViewData["FirstTeamName"] = new SelectList(_context.SportGames, "GameId", "FirstTeamName");
            return View("CreateEdit");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            var game = await _context.SportGames.FindAsync(id);

            if (game == null) 
            {
                return NotFound();
            }
            return View(game);
        }
    }
}
