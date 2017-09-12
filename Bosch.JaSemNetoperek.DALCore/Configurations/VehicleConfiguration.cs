using Bosch.JaSemNetoperek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bosch.JaSemNetoperek.DALCore.Configurations
{
    class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.OwnsOne(c => c.Location);
            
            // Dostosowanie TPH
            builder.HasDiscriminator<string>("VehicleType")
                .HasValue<Car>("C")
                .HasValue<MotorBike>("M")
                .HasValue<Bike>("B")
                .HasValue<Airplane>("A");
        }
    }
}
