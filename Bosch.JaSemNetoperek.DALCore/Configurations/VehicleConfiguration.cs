using System;
using System.Collections.Generic;
using System.Text;
using Bosch.JaSemNetoperek.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bosch.JaSemNetoperek.DALCore.Configurations
{
    class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.OwnsOne(p => p.Location);

            builder.HasDiscriminator<string>("VehicleType")
                .HasValue<Car>("C")
                .HasValue<MotorBike>("M")
                .HasValue<Airplane>("A")
                .HasValue<Bike>("B");

        }
    }
}
