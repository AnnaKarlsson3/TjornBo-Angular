using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace backend.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepo;
        private readonly IBrokerRepository _brokerRepo;
       

        public HouseService (IHouseRepository houseRepo, IBrokerRepository brokerRepo)
        {
            _houseRepo = houseRepo;
            _brokerRepo = brokerRepo;
        }


        public async Task<List<HouseDto>> GetAllHousesAsync()
        {
            var houses = await _houseRepo.GetAllAsync();
            return houses.Select(h => h.ToHouseDto()).ToList();
        }

        public async Task<HouseDto?> GetHouseById(int id)
        {
            var house = await _houseRepo.Find(id);
            
            if (house == null){
                return null;
            }

            var broker = await _brokerRepo.Find(house.BrokerId);

            //TODO -> Nånting är fel här! broker sets ej!
            //Lägg till broker null check...
             house.Broker = new Broker
            {
                Id = broker.Id,
                Name = broker.Name,
                Email = broker.Email,
                PhoneNumber = broker.PhoneNumber
            }; 

            return house.ToHouseDto();
        }

        
        public async Task<House> CreateHouseWithDetailsAsync(CreateHouseDto houseDto )
        {
            var houseModel = houseDto.ToHouseFromCreateDto();
            return await _houseRepo.SaveChanges(houseModel);   
        }
    }
}