using Bosch.JaSemNetoperek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bosch.JaSemNetoperek.DALCore.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.LastName)
             .HasMaxLength(50)
             .IsRequired();


        }
    }
}
