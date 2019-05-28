using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicMood.Core.Models;
using MusicMood.Infrastructure;
using MusicMood.Models;

namespace MusicMood.Controllers
{
    public class ArtistsController : Controller
    {
        private MusicMoodContext _context;

        public ArtistsController(MusicMoodContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var artists = _context.Artists.Select(ToViewModel).ToList();
            return View(artists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArtistViewModel model)
        {
            var artist = new ArtistModel
            {
                Name = model.Name,
                MusicGenre = model.MusicGenre,
                Country = model.Country
            };
            _context.Add(artist);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var artist = _context.Artists.Find(id);
            var model = ToViewModel(artist);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var artist = _context.Artists.Find(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var artist = _context.Artists.Find(id);
            var model = ToViewModel(artist);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ArtistViewModel model)
        {
            var artist = _context.Artists.Find(model.Id);
            artist.Name = model.Name;
            artist.Country = model.Country;
            artist.MusicGenre = model.MusicGenre;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private ArtistViewModel ToViewModel(ArtistModel model)
        {
            var viewModel = new ArtistViewModel
            {
                Id = model.Id,
                Country = model.Country,
                MusicGenre = model.MusicGenre,
                Name = model.Name,
            };

            return viewModel;
        }
    }
}