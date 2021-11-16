using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Model;
using WebServer.Persistence;

namespace WebServer.Data
{
    public class ImpAdultData : IAdultData
    {
        private IList<Adult> adults;
        private FileContext persistence;

        public ImpAdultData()
        {
            persistence = new FileContext();
            adults = persistence.Adults;
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> temp = new List<Adult>(adults);

            return temp;
        }


        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = adults.Max(a => a.Id);
            adult.Id = ++max;
            persistence.AddAdult(adult);
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            persistence.RemoveAdult(adultId);
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            try
            {
                persistence.EditAdult(adult);
                return adult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }
    }
}