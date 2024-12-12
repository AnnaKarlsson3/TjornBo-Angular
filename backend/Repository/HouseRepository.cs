using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class HouseRepository : IHouseRepository
    {
        private readonly ApplicationDbContext _context;
        public HouseRepository(ApplicationDbContext context){
            _context = context;
        }

        public async Task<House> Find(int id)
        {
            var house = await _context.Houses
            .Include(h => h.Address)
            .Include(h => h.Broker)
            .Include(h => h.Owners)
            .FirstOrDefaultAsync(h => h.Id == id);

            return house;
        }

        public async Task<List<House>> GetAllAsync()
        {
            return await _context.Houses
                .Include(h => h.Address) 
                .Include(h => h.Broker)  
                .Include(h => h.Owners)  
                .ToListAsync();          
        }

        public async Task<House> SaveChanges(House houseModel)
        {
             _context.Houses.Add(houseModel);
            await _context.SaveChangesAsync();
            return houseModel;
        }
    }
}