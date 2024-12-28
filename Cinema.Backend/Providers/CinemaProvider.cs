using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Cinema.Backend.Models;

namespace Cinema.Backend.Providers
{
    public class CinemaProvider : ICinemaProvider
    {
        private List<MyCinema> _cinemas;
        private readonly string _path = "Data/cinemas.json";

        public CinemaProvider()
        {
            LoadData();
        }

        
        private void LoadData()
        {
            if (File.Exists(_path))  
            {
                var jsonContent = File.ReadAllText(_path); 
                _cinemas = JsonSerializer.Deserialize<List<MyCinema>>(jsonContent) ?? new List<MyCinema>(); 
            }
            else
            {
                _cinemas = new List<MyCinema>(); 
            }
        }

        
        private void Save()
        {
            var json = JsonSerializer.Serialize(_cinemas); 
            File.WriteAllText(_path, json); 
        }

       
        public void Update(MyCinema newCinema)
        {
            var oldCinema = _cinemas.FirstOrDefault(x => x.Id == newCinema.Id); 
            if (oldCinema == null) return; 
            _cinemas.Remove(oldCinema); 
            _cinemas.Add(newCinema); 
            Save(); 
        }

        
        public void Delete(int id)
        {
            var oldCinema = _cinemas.FirstOrDefault(x => x.Id == id); 
            if (oldCinema == null) return; 
            _cinemas.Remove(oldCinema); 
            Save(); 
        }

        
        public MyCinema[] GetAll()
        {
            return _cinemas.ToArray(); 
        }

      
        public void AddCinema(MyCinema newCinema)
        {
            _cinemas.Add(newCinema); 
            Save(); 
        }
    }
}



 // _cinemas.Add(new MyCinema()
            // {
            //     Name = "Планета зверей",
            //     Id = 1,
            //     Image = @"assets/posters/planeta.png",
            //     Video = @"assets/video/planeta.mp4",
            //     Year = 2018,
            //     Age = "16+",
            //     Country = "Китай",
            //     Time = "Время - 2 ч 12 мин",
            //     Description = "Актер - неудачник Чжэн Кайси, работающий клоуном, сталкивается со сложной жизненной ситуацией: его мать уже несколько лет лежит в коме, а самого парня подставляет лучший друг. Теперь Кайси потерял отцовскую квартиру и остался должен невероятную сумму. Но судьба дает ему шанс. Оказывается, существует загадочный корабль, на котором любому желающему предлагают сыграть в камень-ножницы-бумага, и где можно встретить людей со всего света, даже русских. На кону — списание всех денежных долгов. Кайси решает принять участие в игре.",
            //     Rating = "6.7 из 10",
            //     Actors = new List<Actor>
            //     {
            //         new Actor { Name = "Actor 1", Photo = "assets/actors/image1.png"},
            //         new Actor { Name = "Actor 2", Photo = "assets/actors/image2.png"},
            //         new Actor { Name = "Actor 3", Photo = "assets/actors/image3.png"},
            //         new Actor { Name = "Actor 4", Photo = "assets/actors/image4.png"},
            //         new Actor { Name = "Actor 5", Photo = "assets/actors/image5.png"},
            //     }
            //    
            // });
            //
            // _cinemas.Add(new MyCinema()
            // {
            //     Name = "cinema 2",
            //     Id = 2,
            //     Image = @"Images/planeta.png",
            //     Video = @"",
            //     Year = 2020,
            //     Age = "18+",
            //     Country = "Россия",
            //     Time = "50 мин",
            //     Description = "Блаблабла",
            //     Rating = "6 из 10",
            // });
            //
            // _cinemas.Add(new MyCinema()
            // {
            //     Name = "cinema 3",
            //     Id = 3,
            //     Image = @"Images/planeta.png",
            //     Video = @"Images/planeta.mp4",
            //     Year = 2020,
            //     Age = "18+",
            //     Country = "Россия",
            //     Time = "50 мин",
            //     Description = "Блаблабла",
            //     Rating = "6 из 10",
            //     
            // });