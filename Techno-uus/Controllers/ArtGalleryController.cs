
using Microsoft.AspNetCore.Mvc;

namespace Techno_uus.Controllers
{
    public class ArtGalleryController : Controller
    {
        private readonly AppDbContext _context;
        public ArtGalleryController(AppDbContext context) 
        {
            _context = context;
        }

        //Siin algab Index
        public  IActionResult Index() 
        {
            var artworks = _context.Artworks
                .OrderByDescendig(artworks => artworks.CreationDate)
                .ToList();

            return View(artworks);
        }

        //Siin algab Create 
        public  IActionResult Create() 
        {
            return View();
        }

        //Siin algab Create POST
        [HttpPost]
        public async Task<IActionResult> Create(Art)
    }
}
