using System;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Interfaces;
using WebServer.Model;
using WebServer.Persistence;

namespace WebServer.Repositories {
    public class UserRepo : IUserRepo {
        
        private Hi3Context persistence;

        public UserRepo()
        {
            persistence = new Hi3Context();
        }
        
        public async Task<User> ValidateUser(string username, string password) {
            User u = persistence.Users.FirstOrDefault(tem => tem.Username.Equals(username));
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