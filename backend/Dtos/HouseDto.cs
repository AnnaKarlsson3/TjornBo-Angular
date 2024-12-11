using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos
{
   public class HouseDto
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public int Rooms { get; set; }
    public int SizeM2 { get; set; }
    public string Content { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = null!;
    public BrokerDto Broker { get; set; } = null!;
}

}