using System.Collections.Generic;
using Cinema.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Backend.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Role Role { get; set; }
        
        public SomeClass SomeClass { get; set; }
        
        public IEnumerable<MyCinema> LoveCinemas { get; set; }
    }

    public class SomeClass
    {
        public string Foo { get; set; }
    }
    
    
    public enum Role
    {
        Admin,
        User
    }

   
    
    
    [Route(("api"))]
    public class TestController : Controller
    {
        [HttpGet("")]
        public IActionResult Test(int id, string name)
        {
            return Ok($"hello {name} by id {id}");
        }

        [HttpPost("")]
        public IActionResult Add([FromBody] User user)
        {
            return Ok(user);
        }
    }
}