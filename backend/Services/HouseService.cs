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
        private readonly IBrokerService _brokerService;
       

        public HouseService (IHouseRepository houseRepo, IBrokerRepository brokerRepo, IBrokerService brokerService)
        {
            _houseRepo = houseRepo;
            _brokerRepo = brokerRepo;
            _brokerService = brokerService;
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

           
            return house.ToHouseDto();
        }

        
        public async Task<HouseDto> CreateHouseWithDetailsAsync(CreateHouseDto houseDto )
        {
            var houseModel = houseDto.ToHouseFromCreateDto();
            var house = await _houseRepo.SaveChanges(houseModel);   

            var broker = await _brokerService.GetBrokerById(house.BrokerId);

            Console.WriteLine("Namn: {0} och id: {1}", broker.Name, broker.Id);

            /*  house.Broker = new Broker
            {
                Id = broker.Id,
                Name = broker.Name,
                Email = broker.Email,
                PhoneNumber = broker.PhoneNumber
            };  */


            return house.ToHouseDto();
        }
    }
}