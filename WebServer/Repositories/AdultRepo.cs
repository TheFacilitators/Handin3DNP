using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebServer.Interfaces;
using WebServer.Model;
using WebServer.Persistence;

namespace WebServer.Repositories
{
    public class AdultRepo : IAdultRepo
    {
        private readonly Hi3Context persistence;

        public AdultRepo()
        {
            persistence = new Hi3Context();
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return persistence.Adults.ToList();
        }


        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            persistence.Adults.Add(adult);
            await persistence.SaveChangesAsync();
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            persistence.Adults.Remove(persistence.Adults.First(a => a.Id == adultId));
            await persistence.SaveChangesAsync();
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            persistence.Adults.Update(adult);
            await persistence.SaveChangesAsync();
            return adult;
        }
    }
}