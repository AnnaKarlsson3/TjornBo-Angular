using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Models;

namespace backend.Mappers
{
    public static class HouseMapper
    {
        public static HouseDto ToHouseDto(this House houseModel){
            return new HouseDto{
                Id = houseModel.Id,
                CreationDate = houseModel.CreationDate,
                Price = houseModel.Price,
                Rooms = houseModel.Rooms,
                SizeM2 = houseModel.SizeM2,
                Content = houseModel.Content,
                Address = new AddressDto
                {
                    Street = houseModel.Address?.Street ?? string.Empty,
                    City = houseModel.Address?.City ?? string.Empty,
                    PostalCode = houseModel.Address.PostalCode ?? string.Empty
                },
                Broker = new BrokerDto
                {
                    Name = houseModel.Broker?.Name ?? string.Empty,
                    Email = houseModel.Broker?.Email ?? string.Empty,
                    PhoneNumber = houseModel.Broker?.PhoneNumber ?? string.Empty
                }

            };
        }
    }
}