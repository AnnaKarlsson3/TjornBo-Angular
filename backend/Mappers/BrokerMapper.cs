using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Models;

namespace backend.Mappers
{
    public static class BrokerMapper
    {
        public static BrokerDto ToBrokerDto(this Broker brokerModel){
            return new BrokerDto{
                Id = brokerModel.Id,
                Name = brokerModel.Name,
                Email = brokerModel.Email,
                PhoneNumber = brokerModel.PhoneNumber
            };
        }
        
    }
}




     