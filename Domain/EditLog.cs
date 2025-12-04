using System.ComponentModel.DataAnnotations;

namespace Domain;

public class EditLog
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public DateTime EditedAt { get; set; }
    [Required]
    public string Reason { get; set; } = string.Empty;
    [Required]
    public float PreviousHoursWorked { get; set; }
    [Required]
    public float NewHoursWorked { get; set; }
    
    [Required]
    public User EditedBy { get; set; } = null!;
    [Required]
    public Guid EditedById { get; set; }
    [Required]
    public TimeEntry TimeEntry { get; set; } = null!;
    [Required]
    public Guid TimeEntryId { get; set; }
}