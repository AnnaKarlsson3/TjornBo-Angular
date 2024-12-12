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
    public class BrokerRepository : IBrokerRepository
    {

        private readonly ApplicationDbContext _context;
        public BrokerRepository(ApplicationDbContext context){
            _context = context;
        }
        public async Task<Broker?> Find(int Id)
        {
            return await _context.Brokers.FirstOrDefaultAsync(h => h.Id == Id);
        }
    }
}