using Bosch.JaSemNetoperek.DAL;
using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.DbServices
{
    public class DbService<T> : IBaseService<T>
        where T : Base
    {
        private readonly NetoperekContext context = new NetoperekContext();

        public void Add(T item)
        {
            context.Set<T>().Add(item);

            context.SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return context.Set<T>().SingleOrDefault(p => p.Id == id);
        }
    }

    public class DbUsersService : DbService<User>, IUsersService
    {
          
    }
}
