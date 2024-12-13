using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;


namespace backend.Services
{ 
    public class BrokerService : IBrokerService
    {
        private readonly IBrokerRepository _brokerRepo;

        public BrokerService (IBrokerRepository brokerRepo)
        {
            _brokerRepo = brokerRepo;
        }

        public async Task<Broker?> GetBrokerById(int Id)
        {
            var broker = await _brokerRepo.Find(Id);
            return broker;
        }

    }
}