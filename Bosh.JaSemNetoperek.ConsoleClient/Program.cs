using Bosch.JaSemNetoperek.DAL;
using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosh.JaSemNetoperek.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            AddUserTest();
        }

        private static void AddUserTest()
        {
            var user = new User
            {
                FirstName = "Marcin",
                LastName = "Sulecki"
            };

            using (var context = new NetoperekContext())
            {
                context.Users.Add(user);

                context.SaveChanges();
            }






        }
    }
}
