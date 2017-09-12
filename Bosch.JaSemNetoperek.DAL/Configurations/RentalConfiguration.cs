using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.DAL.Configurations
{
    class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
            // ToTable("wypozyczenia");

            // klucz zlozony
            // HasKey(p => new { p.FromDate, p.ToDate });


            // Property(p => p.FromDate).HasColumnType("datetime2");
                

        }
    }
}
