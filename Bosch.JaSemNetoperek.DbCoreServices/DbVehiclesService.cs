using System;
using System.Collections.Generic;
using System.Text;
using Bosch.JaSemNetoperek.DALCore;
using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;

namespace Bosch.JaSemNetoperek.DbCoreServices
{
    public class DbVehiclesService : IVehiclesService
    {
        protected readonly NetoperekContext context;

        public DbVehiclesService()
            : this(new NetoperekContext())
        {
        }

        public DbVehiclesService(NetoperekContext context)
        {
            this.context = context;

            context.Database.EnsureCreated();
        }

        public void Add(Vehicle item)
        {
            context.Vehicles.Add(item);

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Vehicle> Get<T>() where T : Vehicle
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> Get()
        {
            throw new NotImplementedException();
        }

        public Vehicle Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle item)
        {
            throw new NotImplementedException();
        }
    }
}
