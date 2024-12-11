

using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace backend.Models{

    public class House{
        public int Id { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        //one-to-one
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Rooms { get; set; }
        public int SizeM2 { get; set; }
        public string Content { get; set; } = string.Empty;
        
        //one-to-one
        public int BrokerId { get; set; }
        public Broker Broker { get; set; } = null!;
        
        // Many-to-many relationship with Houses
        public ICollection<Owner> Owners { get; set; } = new List<Owner>();
    }



}