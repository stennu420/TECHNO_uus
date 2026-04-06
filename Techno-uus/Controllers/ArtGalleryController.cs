using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techno_uus.Data;
using Techno_uus.Models;

namespace Techno_uus.Controllers
{
    public class ArtGalleryController : Controller
    {
        private readonly SchoolContext _context;
        private readonly IWebHostEnvironment _environment;

        public ArtGalleryController(SchoolContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index() 
        {
            return View(await _context.ArtGalleries.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var model = new ArtGallery();

            model.PupilName = User.Identity != null && User.Identity.IsAuthenticated
                ? User.Identity.Name ?? "Anonüümne"
                : "Anonüümne";

            model.SubmittedAt = DateTime.Now;

            return View(model);
        }


    }
}