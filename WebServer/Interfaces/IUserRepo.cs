using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Authentication {
    public interface IUserRepo {
        
        Task<User> ValidateUser(string username, string password);
    }
}