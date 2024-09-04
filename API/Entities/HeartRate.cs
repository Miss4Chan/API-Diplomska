using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class HeartRate
{
    [Key]
    public int HeartRateId { get; set; }
    public int UserId { get; set; }
    public DateTime Timestamp { get; set; }
    public double Measurement { get; set; }

    // Navigation properties
    public required AppUser User { get; set; }
}
