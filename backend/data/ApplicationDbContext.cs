using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.data
{

   public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions){
        public required DbSet<House> Houses { get; set; }
        public required DbSet<Address> Addresses { get; set; }
        public required DbSet<Owner> Owners { get; set; }
        public required DbSet<Broker> Brokers { get; set; }

    }
}