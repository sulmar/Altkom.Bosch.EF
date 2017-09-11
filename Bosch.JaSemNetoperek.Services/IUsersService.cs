using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bosch.JaSemNetoperek.Services
{
    public interface IBaseService<T>
        where T : class
    {
        void Add(T item);

        IEnumerable<T> Get();

        //void Update(T item);

        //void Remove(int id);

        T Get(int id);


    }

    public interface IUsersService : IBaseService<User>
    {
    }

    public interface IStationsService : IBaseService<Station>
    {
    }

    public interface IRentalsService : IBaseService<Rental>
    {

    }
}
