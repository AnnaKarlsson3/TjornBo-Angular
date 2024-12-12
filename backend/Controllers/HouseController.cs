using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Dtos;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers
{
    [Route ("api/house")]
    [ApiController]
    public class HouseController : ControllerBase
    {
         private readonly IHouseService _houseService;
     
        public HouseController(IHouseService houseService)
        {
           _houseService = houseService;
        }

        //GET
        [HttpGet]
       public async Task<IActionResult> GetAll()
        {
            // Fetch houses asynchronously
            var houses = await _houseService.GetAllHousesAsync();

            return Ok(houses);
        }

        //GET ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var house = await _houseService.GetHouseById(id);

            if(house == null){
                return NotFound();
            }

            return Ok(house);
        }


        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHouseDto houseDto ){
            var house = await _houseService.CreateHouseWithDetailsAsync(houseDto);
            
            return CreatedAtAction(nameof(GetById), new {id = house.Id}, house.ToHouseDto());
        }




       
    }
}