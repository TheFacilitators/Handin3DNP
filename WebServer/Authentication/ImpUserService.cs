using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Authentication {
    public class ImpUserService : IUserService {
        
        private List<User> users;

        public ImpUserService() {
            users = new List<User>();
            
            users.Add(new User {Username = "Strawberry", Password = "123456", SecurityLevel = 3});
            users.Add(new User {Username = "Blueberry", Password = "123abc", SecurityLevel = 2});
            users.Add(new User {Username = "Cranberry", Password = "abc123", SecurityLevel = 5});
        }
        
        public async Task<User> ValidateUser(string username, string password) {
            User u = users.FirstOrDefault(tem => tem.Username.Equals(username));
            if (u == null) {
                throw new Exception("There is no such user");
            }

            if (!u.Password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            return u;
        }
    }
}