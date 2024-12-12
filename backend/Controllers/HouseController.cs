using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
            var houses = _context.Houses
            .Include(h => h.Address)
            .Include(h => h.Broker)
            .Include(h => h.Owners) // Include Owners
            .ToList()
            .Select(h => h.ToHouseDto()) // Map to DTOs
            .ToList();
            //Select is same as map

             if (!houses.Any())
            {
                return NotFound("No houses found.");
            }

            return Ok(houses);
        }




       
    }
}