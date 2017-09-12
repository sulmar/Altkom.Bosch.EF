using Bosch.JaSemNetoperek.Services;
using System;
using Bosch.JaSemNetoperek.Models;
using System.Collections.Generic;
using Bosch.JaSemNetoperek.DALCore;
using System.Linq;

namespace Bosch.JaSemNetoperek.DbCoreServices
{
    public class DbStationsService : IStationsService
    {
        protected readonly MyContext context;

        public DbStationsService()
            : this(new MyContext())
        {

        }

        public DbStationsService(MyContext context)
        {
            this.context = context;
        }

        public void Add(Station item)
        {
            context.Add(item);

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Station> Get()
        {
            return context.Stations.ToList();
        }

        public Station Get(int id)
        {
            return context.Stations.Find(id);
        }

        public Station GetByLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Station item)
        {
            throw new NotImplementedException();
        }
    }
}
