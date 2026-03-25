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
           return View(await _context.SportsGames.ToListAsync());
        }

      
    }
}
