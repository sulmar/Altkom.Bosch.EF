using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.DbServices
{


    public class DbUsersService : DbService<User, int>, IUsersService
    {
          
    }

    public class DbStationsService : DbService<Station, int>, IStationsService
    {
        public Station GetByLocation(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
