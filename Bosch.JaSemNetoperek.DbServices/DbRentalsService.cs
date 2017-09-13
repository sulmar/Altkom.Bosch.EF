using Bosch.JaSemNetoperek.DAL;
using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity;

namespace Bosch.JaSemNetoperek.DbServices
{
    public class DbRentalsService : DbService<Rental, int>, IRentalsService
    {

        // Eadger loading
        public override IEnumerable<Rental> Get()
        {            
            return context.Rentals
                .Include(p => p.Rentee)
                .Include(p => p.Vehicle)
                .ToList();
        }

        // obsługa transakcji rozproszonych
        public override void Add(Rental item)
        {            
            context.Rentals.Add(item);

            // pobranie encji z entity state managera
            var entities = context.ChangeTracker.Entries();

            context.Entry(item.FromStation).State = System.Data.Entity.EntityState.Unchanged;
            context.Entry(item.Rentee).State = System.Data.Entity.EntityState.Unchanged;
            context.Entry(item.Vehicle).State = System.Data.Entity.EntityState.Unchanged;

            // NOTE: Add reference to System.Transactions

            using (var scope = new TransactionScope())
            {
                context.SaveChanges();

                using (var context2 = new NetoperekContext())
                {
                    item.FromStation = null;

                    context2.SaveChanges();
                }

                scope.Complete();
            }


        }

        //public override void Add(Rental item)
        //{
        //    using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
        //    {
        //        context.Rentals.Add(item);

        //        // pobranie encji z entity state managera
        //        var entities = context.ChangeTracker.Entries();

        //        context.Entry(item.FromStation).State = System.Data.Entity.EntityState.Unchanged;
        //        context.Entry(item.Rentee).State = System.Data.Entity.EntityState.Unchanged;
        //        context.Entry(item.Vehicle).State = System.Data.Entity.EntityState.Unchanged;

        //        try
        //        {
        //            context.SaveChanges();

        //            item.FromStation = null;

        //            throw new Exception();

        //            context.SaveChanges();

        //            transaction.Commit();
        //        }
        //        catch(Exception)
        //        {
        //            transaction.Rollback();
        //        }
        //    }
        //}
    }
}
