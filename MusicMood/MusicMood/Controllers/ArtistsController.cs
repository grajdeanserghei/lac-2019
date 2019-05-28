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
                Id = 0,
                Name = "Beatles",
                Country = "UK",
            },
        };

        public IActionResult Index()
        {
            return View(_artists);
        }

    }
}