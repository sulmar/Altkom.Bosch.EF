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
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            // zmiana schematu tabeli
            // ToTable("crm.Users");

            HasKey(p => p.UserId);

            Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("MyIndex", 1) { IsUnique = true }));


            Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("MyIndex", 2) { IsUnique = true } ));

            
        }
    }
}
