using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebServer.Model;
using WebServer.Persistence;

namespace WebServer.Seed
{
    public class SeedData
    {
        private readonly Hi3Context persistence;

        public SeedData()
        {
            persistence = new Hi3Context();
            if (!persistence.Users.Any())
            { 
                InitUsers();
            }
            if (!persistence.Adults.Any())
            { 
                InitAdults();
            }
        }

        private void InitUsers()
        {
            Console.WriteLine("Seeding Users...");
            var users = new List<User>
            {
                new User {Username = "Strawberry", Password = "123456", SecurityLevel = 3},
                new User {Username = "Blueberry", Password = "123abc", SecurityLevel = 2},
                new User {Username = "Cranberry", Password = "abc123", SecurityLevel = 5}
            };
            
            foreach (var user in users)
            {
                {
                    persistence.Users.Add(user);
                    persistence.Entry(user).State = EntityState.Added;
                    persistence.SaveChanges();
                }
            }
        }

        private void InitAdults()
        {
            Console.WriteLine("Seeding Adults...");
            //SeedDataAdultsHereFromJsonFile
            var file = new FileContext();
            var adults = file.ReadData<Adult>("adults.json");
                
            foreach (var adult in adults)
            {
                {
                    persistence.Adults.Add(adult);
                    persistence.Entry(adult).State = EntityState.Added;
                    persistence.SaveChanges();
                }
            }
        }
    }
}