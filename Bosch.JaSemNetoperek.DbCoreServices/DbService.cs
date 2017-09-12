using Bosch.JaSemNetoperek.DALCore;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosch.JaSemNetoperek.DbCoreServices
{
    public class DbService<TEntity, TKey> : IBaseService<TEntity, TKey>
       where TEntity : class

    {
        protected readonly MyContext context;

        public DbService()
            : this(new MyContext())
        {

        }

        public DbService(MyContext context)
        {
            this.context = context;
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

        public virtual void Remove(TKey id)
        {
            TEntity item = Get(id);

            context.Set<TEntity>().Remove(item);

            context.SaveChanges();
        }

        public virtual void Update(TEntity item)
        {
            System.Diagnostics.Trace.WriteLine(context.Entry(item).State);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            System.Diagnostics.Trace.WriteLine(context.Entry(item).State);

            context.SaveChanges();
        }
    }
}
