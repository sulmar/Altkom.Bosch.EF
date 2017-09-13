using System;
using System.Collections.Generic;
using System.Linq;
using Bosch.JaSemNetoperek.DALCore;
using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;

namespace Bosch.JaSemNetoperek.DbCoreServices
{
    public class DbUsersService : IUsersService
    {
        protected readonly NetoperekContext context;



        public DbUsersService()
            : this(new NetoperekContext())
        {
        }

        public DbUsersService(NetoperekContext context)
        {
            this.context = context;

            context.Database.EnsureCreated();
        }

        public void Add(User item)
        {
            context.Users.Add(item);

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<User> Get()
        {
            return context.Users.ToList();
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
