using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.DAL
{
    public class NetoperekContext : DbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rental> Rentals { get; set; }


        public NetoperekContext()
            : base("NetoperekConnection")
        {

        }

    }
}
