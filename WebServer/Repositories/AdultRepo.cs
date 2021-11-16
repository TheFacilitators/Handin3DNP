using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebServer.Model;
using WebServer.Persistence;

namespace WebServer.Data
{
    public class AdultRepo : IAdultRepo
    {
        private readonly IList<Adult> adults;
        private readonly Hi3Context persistence;

        public AdultRepo()
        {
            persistence = new Hi3Context();
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            var temp = persistence.Adults.ToList();

            return temp;
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
            /*dult temp = persistence.Adults.First(a => a.Id == adult.Id);

            if (temp == null)
                throw new Exception($"Did not find the person with this id: {adult.Id}");

            temp.Age = adult.Age;
            temp.JobTitle = adult.JobTitle;
            temp.FirstName = adult.FirstName;
            temp.LastName = adult.LastName;*/
            await persistence.SaveChangesAsync();
            return adult;
        }
    }
}