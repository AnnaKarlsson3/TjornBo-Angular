using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.data
{
   public class ApplicationDbContext : DbContext{

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions){

        }


        public DbSet<House> Houses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Broker> Brokers { get; set; }

    }
}