using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Interfaces {
    public interface IAdultRepo {
        
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
        Task<Adult> UpdateAdultAsync(Adult adult);
    }
}