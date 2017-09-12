using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;
using System.Linq;
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
            var station = context.Stations
                .FirstOrDefault(s => s.Location == location);

            return station;

            //IQueryable<Station> nearStations = context.Stations
            //    .Where(s => s.Location == location)
            //    .Where(s => s.Capacity > 10);

            //foreach (var station in nearStations)
            //{

            //}


            //var nearStations2 = context.Stations
            //    .Where(s => s.Location == location)
            //    .Where(s => s.Capacity > 10);
                

            //foreach (var station in nearStations2)
            //{

            //}


            //var q = context.Rentals
            //    .GroupBy(r => r.FromStation)
            //    .Select(r => new { Station = r.Key, Quantity = r.Count() } );


        }
    }
}
