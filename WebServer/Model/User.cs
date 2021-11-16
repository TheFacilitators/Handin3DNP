using System.ComponentModel.DataAnnotations;

namespace WebServer.Model {
    public class User {
        
        [Key, MinLength(2), MaxLength(50)]
        public string Username { get; set; }
        [Required, MinLength(6), MaxLength(50)]
        public string Password { get; set; }
        [Range(1, 5)] [Required]
        public int SecurityLevel { get; set; }
    }
}