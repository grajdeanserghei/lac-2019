using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicMood.Models;

namespace MusicMood.Controllers
{
    public class ArtistsController : Controller
    {
        private static List<ArtistViewModel> _artists = new List<ArtistViewModel>
        {
            new ArtistViewModel
            {
                Id = 0,
                Name = "Metalica",
                Country = "USA",
                MusicGenre = "Rock"
            },
            new ArtistViewModel
            {
                Id = 1,
                Name = "Beatles",
                Country = "UK",
                MusicGenre = "Heavy metal",
            },
        };

        public IActionResult Index()
        {
            return View(_artists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArtistViewModel model)
        {
            var id = 1;
            if(_artists.Count > 0)
            {
                id = _artists.Max(x => x.Id) + 1;
            }
            model.Id = id;
            _artists.Add(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var artist = _artists.FirstOrDefault(x => x.Id == id);
            return View(artist);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var artist = _artists.First(x => x.Id == id);
            _artists.Remove(artist);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var artist = _artists.FirstOrDefault(x => x.Id == id);
            return View(artist);
        }

        [HttpPost]
        public IActionResult Edit(ArtistViewModel model)
        {
            var artist = _artists.FirstOrDefault(x => x.Id == model.Id);
            artist.Name = model.Name;
            artist.Country = model.Country;
            artist.MusicGenre = model.MusicGenre;
            
            return RedirectToAction(nameof(Index));
        }
    }
}