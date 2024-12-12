using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Models;

namespace backend.Interfaces
{
    public interface IHouseService
    {
        Task<List<HouseDto>> GetAllHousesAsync();
        Task<House> CreateHouseWithDetailsAsync(CreateHouseDto houseDto);

        Task<HouseDto> GetHouseById(int id);
    }
}