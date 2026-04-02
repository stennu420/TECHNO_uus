using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
           return View();
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
        public async Task<IActionResult> Edit( SportGames game) 
        {
           
          if (ModelState.IsValid)
          {
                _context.Update(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
          }
            return RedirectToAction("Index");
              
        
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            var game = await _context.SportGames.FindAsync(id);

            if (game == null) 
            {
                return NotFound();
            }

            ViewData["Värv"] = "Edit";
            ViewData["HomeTeamPlayers"] = new SelectList(_context.Pupils, "GameId", "LastName");
            return View("Edit");
            return View(game);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null) 
            {
                return View();
            }

            var game = await _context.SportGames
                .FirstOrDefaultAsync( game => game.GameId == id);

            if (game == null)
            {
                return BadRequest();
            }
            return View(game);


        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) 
            {
                return NotFound();
            }

            var game = await _context.SportGames.FindAsync(id);

            if (game == null) 
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComfirmd(int id) 
        {
            var game = await _context.SportGames.FindAsync(id);

            if (game != null) 
            {
                _context.SportGames.Remove(game);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
