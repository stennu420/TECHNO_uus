using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techno_uus.Data;

namespace Techno_uus.Controllers
{
    public class PupilsController : Controller
    {
        private readonly SchoolContext _context;
        public PupilsController(SchoolContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult>Index()
        {
            return View(await _context.Pupils.ToListAsync());
        }
    }
}
