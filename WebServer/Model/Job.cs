using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebServer.Model
{
    public class Job
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}