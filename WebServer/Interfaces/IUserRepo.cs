using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Interfaces {
    public interface IUserRepo {
        
        Task<User> ValidateUser(string username, string password);
    }
}