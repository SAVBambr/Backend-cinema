using System;
using Cinema.Backend.Models;
using Cinema.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Backend.Controllers
{
    [Route(("api/home"))]
    public class HomeController : Controller
    {
        private readonly HomeService _service;

        public HomeController(HomeService service)
        {
            _service = service;
        }
        
        
        [HttpGet("getRecommendationCinema")]
        public MyCinema[] GetRecommendationCinema()
            => _service.GetRecommendationCinema();

        [HttpGet("getHighlyRatedCinema")]
        public MyCinema[] GetHighlyRatedCinema()
            => _service.GetHighlyRatedCinema();

        [HttpGet("getRecentReleaseCinema")]
        public MyCinema[] GetRecentReleaseCinema()
            => _service.GetRecentReleaseCinema();
    }
}