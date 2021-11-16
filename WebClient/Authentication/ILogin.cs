using System.Threading.Tasks;
using WebClient.Model;

namespace WebClient.Authentication {
    public interface ILogin {
        Task<User> Validate(string username, string password);
    }
}