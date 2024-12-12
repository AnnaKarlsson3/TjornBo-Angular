using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Models;

namespace backend.Interfaces
{
    public interface IHouseRepository
    {
        Task<List<House>> GetAllAsync();
        Task<House> SaveChanges(House housemodel);
        Task<House> Find(int id);
    }
}