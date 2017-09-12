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
    public class DbService<T, TKey> : IBaseService<T, TKey>
        where T : class
        
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

        public T Get(TKey id)
        {
            return context.Set<T>().Find(id);
        }

        public void Remove(TKey id)
        {
            T item = Get(id);

            context.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }

    public class DbUsersService : DbService<User, int>, IUsersService
    {
          
    }
}
