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
            },
            new ArtistViewModel
            {
                Id = 1,
                Name = "Beatles",
                Country = "UK",
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
            var id = _artists.Max(x => x.Id) + 1;
            model.Id = id;
            _artists.Add(model);
            return RedirectToAction(nameof(Index));
        }

    }
}