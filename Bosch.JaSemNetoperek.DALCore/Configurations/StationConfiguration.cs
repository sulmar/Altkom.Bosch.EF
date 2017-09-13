using System;
using System.Collections.Generic;
using System.Text;
using Bosch.JaSemNetoperek.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bosch.JaSemNetoperek.DALCore.Configurations
{
    class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50);

            builder.OwnsOne(p => p.Location);


        }
    }
}
