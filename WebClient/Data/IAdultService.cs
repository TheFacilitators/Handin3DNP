using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Model;

namespace WebClient.Data {
    public interface IAdultService {
        Task<IList<Adult>> GetAdultsAsync();
        Task   AddAdultAsync(Adult adult);
        Task   RemoveAdultAsync(int id);
        Task   UpdateAdultAsync(Adult adult);
        
        Adult GetById(int id);
    }
}