using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.DAL.Conventions
{
    class StringConvention : Convention
    {
        public StringConvention()
        {
            this.Properties<string>()
                .Where(c=>c.Name.Contains("Name"))
                .Configure(c => c.HasMaxLength(255));
        }
    }
}
