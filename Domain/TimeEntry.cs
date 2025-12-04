using System.ComponentModel.DataAnnotations;

namespace Domain;

public class TimeEntry
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    // Maybe change later? HoursWorked could be calculated from StartTime and EndTime so it might be redundant
    public decimal HoursWorked { get; set; }
    public Status Status { get; set; }
    
    [Required]
    public User User { get; set; } = null!;
    [Required]
    public Guid UserId { get; set; }
    public ICollection<EditLog> EditLogs { get; set; } = new List<EditLog>();

    public void CalculateHoursWorked()
    {
        var duration = EndTime - StartTime;
        HoursWorked = (decimal) duration.TotalHours;
    }
}