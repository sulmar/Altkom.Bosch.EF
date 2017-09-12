using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosch.JaSemNetoperek.DbCoreServices
{
    public class DbVehiclesService : DbService<Vehicle, int>, IVehiclesService
    {
        public new IEnumerable<Vehicle> Get<T>()
            where T : Vehicle
        {
            return context.Vehicles.OfType<T>();
        }
    }
}
