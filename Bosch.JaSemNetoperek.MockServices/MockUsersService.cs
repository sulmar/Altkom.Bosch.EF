using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.MockServices
{
    public class MockUsersService : IUsersService
    {
        private IList<User> users = new List<User>();

        public void Add(JaSemNetoperek.Models.User item)
        {
            users.Add(item);
        }

        public void Dispose()
        {
            users.Clear();
        }

        public System.Collections.Generic.IEnumerable<JaSemNetoperek.Models.User> Get()
        {
            return users;
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAsync()
        {
            return Task.Run(() => Get());
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void SetIsDeletedStatus(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
