using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.DAL.Configurations
{
    class StationConfiguration : EntityTypeConfiguration<Station>
    {
        public StationConfiguration()
        {

            // Indeks unikalny
            Property(p => p.Name)
              .HasMaxLength(20)
              .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute { IsUnique = true }));
              ;

            
        }
    }
}
