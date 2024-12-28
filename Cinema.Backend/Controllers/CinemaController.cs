using Cinema.Backend.Models;
using Cinema.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Backend.Controllers
{
    [Route(("api/cinema"))]
    
    public class CinemaController : Controller
    {
        private readonly CinemaService _service;
        
        public CinemaController(CinemaService service)
        {
            _service = service;
        }
        
        
        [HttpGet("getAll")]
        public MyCinema[] GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost("addCinema")]
        public IActionResult AddCinema([FromBody] MyCinema newCinema)
        {
            if (newCinema == null)
            {
                return BadRequest("Invalid cinema data.");
            }

            _service.AddCinema(newCinema);
            return Ok("Cinema added successfully.");
        }

        [HttpPost("updateCinema")]
        public IActionResult UpdateCinema([FromBody] MyCinema newCinema)
            => Ok(_service.UpdateCinema(newCinema));
        
        

        [HttpGet("get")]
        public MyCinema Get(int id)
        {
            return _service.GetById(id);
        }
        
        [HttpGet("delete")]
        public void Delete(int id)
        {
            _service.DeleteById(id);
        }
        
    }
}