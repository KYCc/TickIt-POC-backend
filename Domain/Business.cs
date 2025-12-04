using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Business
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<User> Users { get; set; } = new List<User>();
}