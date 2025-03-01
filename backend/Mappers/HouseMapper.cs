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
                Address = houseModel.Address == null
                    ? new AddressDto()
                    : new AddressDto
                    {
                        Street = houseModel.Address.Street ?? string.Empty,
                        City = houseModel.Address.City ?? string.Empty,
                        PostalCode = houseModel.Address.PostalCode ?? string.Empty,
                    },
                Broker = houseModel.Broker == null
                    ? new BrokerDto()
                    : new BrokerDto
                    {
                        Id = houseModel.Broker.Id,
                        Name = houseModel.Broker.Name ?? string.Empty,
                        Email = houseModel.Broker.Email ?? string.Empty,
                        PhoneNumber = houseModel.Broker.PhoneNumber ?? string.Empty,
                    },
                Owners = houseModel.Owners.Select(o => new OwnerDto
                {
                    Name = o.Name,
                    Email = o.Email,
                    PhoneNumber = o.PhoneNumber
                }).ToList() 

            };
        }


        public static House ToHouseFromCreateDto(this CreateHouseDto house){
            return new House{
                Price = house.Price,
                Rooms = house.Rooms,
                SizeM2 = house.SizeM2,
                Content = house.Content,
                BrokerId = house.BrokerId,
                Address = new Address
                {
                    Street = house.Address.Street,
                    City = house.Address.City,
                    PostalCode = house.Address.PostalCode
                },
                Owners = house.Owners.Select(o => new Owner
                {
                    Name = o.Name,
                    IDNumber = o.IDNumber,
                    Email = o.Email,
                    PhoneNumber = o.PhoneNumber
                }).ToList()
            };
        }
    }
}