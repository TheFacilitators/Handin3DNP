using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Model;

namespace WebClient.Data {
    public class ImpAdultService : IAdultService {
        private IList<Adult> adults;
        private readonly HttpClient client;
        private string uri = "https://localhost:5003";

        public ImpAdultService() {
            adults = new List<Adult>();
            client = new HttpClient();
        }


        public async Task<IList<Adult>> GetAdultsAsync() {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Adult");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error:{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            adults = JsonSerializer.Deserialize<IList<Adult>>(result, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });


            return adults;
        }

        public async Task AddAdultAsync(Adult adult) {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Adult", content);
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task RemoveAdultAsync(int id) {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"{uri}/Adult/{id}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error:{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task UpdateAdultAsync(Adult adult) {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PatchAsync($"{uri}/Adult/{adult.Id}", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }
        
        public Adult GetById(int id) {
            return adults.First(a => a.Id == id);
        }
    }
}