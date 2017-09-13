using Bosch.JaSemNetoperek.DAL;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bosch.JaSemNetoperek.DbServices
{
    public class DbService<TEntity, TKey> : IBaseService<TEntity, TKey>
        where TEntity : class
        
    {
        protected readonly NetoperekContext context;

        public DbService()
            : this(new NetoperekContext())
        {
            
        }
        
        public DbService(NetoperekContext context)
        {
            this.context = context;

            this.context.Database.Log = Console.WriteLine;

            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Configuration.ProxyCreationEnabled = false;
        }

        public virtual void Add(TEntity item)
        {
            System.Diagnostics.Trace.WriteLine(context.Entry(item).State);

            context.Set<TEntity>().Add(item);

            System.Diagnostics.Trace.WriteLine(context.Entry(item).State);

            context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get(TKey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public virtual void Remove(TKey id)
        {
            TEntity item = Get(id);

            context.Set<TEntity>().Remove(item);

            context.SaveChanges();
        }

        public virtual void Update(TEntity item)
        {
            System.Diagnostics.Trace.WriteLine(context.Entry(item).State);

            context.Entry(item).State = System.Data.Entity.EntityState.Modified;

            // modyfikacja pojedynczej wlasciwosci 
            // context.Set<TEntity>().Attach(item);
            // context.Entry(item).Property("Name").IsModified = true;


            System.Diagnostics.Trace.WriteLine(context.Entry(item).State);

            try
            {
                context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new InvalidOperationException("Obiekt zostal juz zmodyfikowany");
            }
            // NotImplementedException();
        }
    }
}
