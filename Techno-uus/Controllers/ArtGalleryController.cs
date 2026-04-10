using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techno_uus.Data;
using Techno_uus.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Techno_uus.Controllers
{
    public class ArtGalleryController : Controller
    {
        private readonly SchoolContext _context;


        public ArtGalleryController(SchoolContext context)
        {
            _context = context;
            
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ArtGallery.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArtGallery art, string ImageUrl)
        {

            ArtGallery newArt = new ArtGallery();
            {

            
                newArt.PupilId = art.PupilId;
                newArt.PupilName = art.PupilName;
                newArt.ArtId = Guid.NewGuid();
                newArt.ArtWorkTitle = art.ArtWorkTitle;

                if (!string.IsNullOrEmpty(ImageUrl)) 
                {
                    newArt.ImagePath = ImageUrl;
                }
                else 
                {
                    newArt.ImagePath = null;
                }
                newArt.Image = null;
                newArt.ImagePath = art.ImagePath;
                newArt.Description = art.Description;
                newArt.ArtWorkDescription = art.ArtWorkDescription;
                newArt.CreationDate = DateOnly.FromDateTime(DateTime.Now);
                newArt.SubmittedAt = DateTime.Now;

                
            };

                _context.Add(newArt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            
            
        }


        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var art = await _context.ArtGallery
                .Where(a => a.ArtId == Guid.Parse(id))
                .Select(a => new ArtGallery
                {
                    ArtId = a.ArtId,
                    PupilName = a.PupilName,
                    ArtWorkTitle = a.ArtWorkTitle,
                    ArtWorkDescription = a.ArtWorkDescription,
                    Description = a.Description,
                    ImagePath = a.ImagePath,
                    SubmittedAt = a.SubmittedAt,
                    CreationDate = a.CreationDate
                })
                .FirstOrDefaultAsync();
            if (art == null)
            {
                return NotFound();
            }

            return View(art);
            // Image = new List<ArtGalleryListImageViewModel>(
            //_context.GalleryImages
            //     .Where(i => i.ListID == a.ArtId)
            //    .Select(li => new ArtGalleryListImageViewModel
            //    {
            //        ListID = li.ListID,
            //        ImageID = li.ImageID,
            //       ImageData = li.ImageData,
            //       ImageTitle = li.ImageTitle,
            //       Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(li.ImageData))
            //   })



        }
                
        [HttpGet]
        public async Task<IActionResult> Delete(string? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var ArtGallery = await _context.ArtGallery
                .FirstOrDefaultAsync(a => a.ArtId == Guid.Parse(id));
            if(ArtGallery == null) 
            {
                return NotFound();
            }
            return View(ArtGallery);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var art = await _context.ArtGallery
                  .FirstOrDefaultAsync(a => a.ArtId == Guid.Parse(id)); 
            if(art != null) 
            {
                _context.ArtGallery.Remove(art);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
            
        }
    }
}