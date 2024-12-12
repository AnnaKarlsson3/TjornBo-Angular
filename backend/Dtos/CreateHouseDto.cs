using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos
{
    public class CreateHouseDto
    {
    public required CreateAddressDto Address { get; set; }
    public decimal Price { get; set; }
    public int Rooms { get; set; }
    public int SizeM2 { get; set; }
    public string Content { get; set; } = string.Empty;
    public int BrokerId { get; set; }
    public List<CreateOwnerDto> Owners { get; set; } = new List<CreateOwnerDto>();
    }
}