using System.Collections.Generic;

namespace Cinema.Backend.Models
{
    
    public class Actor
    {
        public string Name { get; set; }
        public string Photo { get; set; }
    }
    
    public class MyCinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Image { get; set; }
        public int Year { get; set; }
        public string Age { get; set; }
        
        public string Country { get; set; }
        
        public string Time { get; set; }
        
        public string Description { get; set; }
        
        public int Rating { get; set; }

        public string Video { get; set; }
        
        public bool IsRecommendation { get; set; }
    }
}