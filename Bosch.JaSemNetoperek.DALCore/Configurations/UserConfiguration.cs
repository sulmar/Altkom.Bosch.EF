using System;
using System.Collections.Generic;
using System.Text;
using Bosch.JaSemNetoperek.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bosch.JaSemNetoperek.DALCore.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
