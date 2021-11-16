using System.ComponentModel.DataAnnotations;

namespace WebClient.Model {
public class Person {
    
    public int Id { get; set; }
    [Required, MinLength(2), MaxLength(100)]
    public string FirstName { get; set; }
    [Required, MinLength(1), MaxLength(100)]
    public string LastName { get; set; }
    public int Age { get; set; }
}


}