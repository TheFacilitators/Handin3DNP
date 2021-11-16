using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Authentication {
    public interface IUserService {
        
        Task<User> ValidateUser(string username, string password);
    }
}