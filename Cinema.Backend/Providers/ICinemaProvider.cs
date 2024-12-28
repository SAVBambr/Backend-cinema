using Cinema.Backend.Models;

namespace Cinema.Backend.Providers
{
    public interface ICinemaProvider
    {
        MyCinema[] GetAll(); 
        void AddCinema(MyCinema newCinema); 
        void Update(MyCinema cinema); 
        void Delete(int id); 
    }
}