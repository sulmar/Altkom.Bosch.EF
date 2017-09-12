using Bosch.JaSemNetoperek.DAL;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosch.JaSemNetoperek.DbServices
{
    public class DbService<TEntity, TKey> : IBaseService<TEntity, TKey>
        where TEntity : class
        
    {
        protected readonly NetoperekContext context = new NetoperekContext();

        public void Add(TEntity item)
        {
            context.Set<TEntity>().Add(item);

            context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Get(TKey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Remove(TKey id)
        {
            TEntity item = Get(id);

            context.Set<TEntity>().Remove(item);

            context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
