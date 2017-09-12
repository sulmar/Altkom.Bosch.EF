using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bosch.JaSemNetoperek.Services
{
    public interface IBaseService<T, TKey>
        where T : class
    {
        void Add(T item);

        IEnumerable<T> Get();

        void Update(T item);

        void Remove(TKey id);

        T Get(TKey id);


    }

    public interface IUsersService : IBaseService<User, int>
    {
    }

    public interface IStationsService : IBaseService<Station, int>
    {
    }

    public interface IRentalsService : IBaseService<Rental, int>
    {

    }
}
