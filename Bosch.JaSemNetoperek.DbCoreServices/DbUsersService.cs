using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.DALCore;

namespace Bosch.JaSemNetoperek.DbCoreServices
{
    public class DbUsersService : IUsersService
    {
        protected readonly MyContext context;

        public DbUsersService()
            : this(new MyContext())
        {

        }

        public DbUsersService(MyContext context)
        {
            this.context = context;

            context.Database.EnsureCreated();
        }

        public void Add(User item)
        {
            context.Add(item);

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
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
