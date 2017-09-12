using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.DAL.Configurations
{
    class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            Map<Car>(m => m.Requires("VehicleType").HasValue("C"));
            Map<Airplane>(m => m.Requires("VehicleType").HasValue("A"));
            Map<MotorBike>(m => m.Requires("VehicleType").HasValue("M"));
            Map<Bike>(m => m.Requires("VehicleType").HasValue("B"));


        }
    }
}
