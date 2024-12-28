using System;
using Cinema.Backend.Models;
using Cinema.Backend.Providers;

namespace Cinema.Backend.Services
{
    public class CinemaService
    {
        private readonly ICinemaProvider _provider;
        
        public CinemaService(ICinemaProvider provider)
        {
            _provider = provider;
        }
        
        public MyCinema[] GetAll()
        {
            return _provider.GetAll(); 
        }

        // Добавить новый кинофильм
        public void AddCinema(MyCinema newCinema)
        {
            _provider.AddCinema(newCinema); // Используем метод интерфейса
        }

        // Обновить существующий кинофильм
        public bool UpdateCinema(MyCinema cinema)
        {
            if (cinema.Id == 0)
                return false;

            _provider.Update(cinema); // Используем метод интерфейса
            return true;
        }

       
        public MyCinema GetById(int id)
        {
            var allCinema = _provider.GetAll();
            foreach (var x in allCinema)
            {
                if (x.Id == id)
                    return x;
            }

            throw new InvalidOperationException();
        }

        // Удалить кинофильм по ID
        public void DeleteById(int id)
        {
            _provider.Delete(id); // Используем метод интерфейса
        }
    }
}