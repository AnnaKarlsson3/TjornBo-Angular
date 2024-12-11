using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route ("api/house")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public IActionResult GetAll(){
                                        //defird execution
            var houses = _context.Houses.ToList();
             if (!houses.Any())
            {
                return NotFound("No houses found.");
            }

            return Ok(houses);
        }




       
    }
}