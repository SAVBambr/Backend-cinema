using System.Collections.Generic;
using Cinema.Backend.Models;
using Cinema.Backend.Providers;

namespace Cinema.Backend.Services
{
    public class HomeService
    {
        private readonly CinemaProvider _cinemaProvider;
        
        public HomeService(CinemaProvider cinemaProvider)
        {
            _cinemaProvider = cinemaProvider;
        }
        
        
        public MyCinema[] GetRecommendationCinema()
        {
            var allCinemas = _cinemaProvider.GetAll();

            var buffer = new List<MyCinema>();  

            foreach (var cinema in allCinemas)
            {
                if(cinema.IsRecommendation)
                    buffer.Add(cinema);
            }

            return buffer.ToArray();
        }
        
        public MyCinema[] GetHighlyRatedCinema()
        {
            var allCinemas = _cinemaProvider.GetAll();

            var buffer = new List<MyCinema>();  

            foreach (var cinema in allCinemas)
            {
                if(cinema.Rating > 8)
                    buffer.Add(cinema);
            }

            return buffer.ToArray();
        }
        
        public MyCinema[] GetRecentReleaseCinema()
        {
            var allCinemas = _cinemaProvider.GetAll();

            var buffer = new List<MyCinema>();  

            foreach (var cinema in allCinemas)
            {
                if(cinema.Year >= 2023)
                    buffer.Add(cinema);
            }

            return buffer.ToArray();
        }
    }
}