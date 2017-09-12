﻿using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bosch.JaSemNetoperek.Services
{
    public interface IBaseService<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        void Add(TEntity item);

        IEnumerable<TEntity> Get();

        void Update(TEntity item);

        void Remove(TKey id);

        TEntity Get(TKey id);


    }

    public interface IUsersService : IBaseService<User, int>
    {
    }

    public interface IStationsService : IBaseService<Station, int>
    {
        Station GetByLocation(Location location);
    }

    public interface IRentalsService : IBaseService<Rental, int>
    {

    }

    public interface IVehiclesService : IBaseService<Vehicle, int>
    {

        IEnumerable<Vehicle> Get<T>() where T : Vehicle;
        
            

    }
}
