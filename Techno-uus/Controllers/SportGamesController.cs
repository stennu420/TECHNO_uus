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
        public enum GameStatus 
        {
            Voit,
            Viik,
            Kaotus
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id) 
        {
          if (ModelState.IsValid) 
          {

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
          }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit (int? id) 
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
