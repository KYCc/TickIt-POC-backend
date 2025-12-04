using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Role Role { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required] 
    public Business Business { get; set; } = null!;
    [Required]
    public Guid BusinessId { get; set; }
    public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
}