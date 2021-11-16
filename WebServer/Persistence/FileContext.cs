using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebServer.Model;

namespace WebServer.Persistence
{
    public class FileContext 
    {
        public IList<Adult> Adults { get; private set; }
        
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        protected internal IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public void AddAdult(Adult a) {
            Adults.Add(a);
            SaveChanges();
        }

        public void EditAdult(Adult adult) {
           Adult temp = Adults.First(a => a.Id == adult.Id);
           
           if (temp == null)
               throw new Exception($"Did not find the person with this id: {adult.Id}");
           
           temp.Age = adult.Age;
           temp.JobTitle = adult.JobTitle;
           temp.FirstName = adult.FirstName;
           temp.LastName = adult.LastName;
           SaveChanges();
        }

        public void RemoveAdult(int id) {
            Adults.Remove(Adults.First(a => a.Id == id));
            SaveChanges();
        }
    
    }
}