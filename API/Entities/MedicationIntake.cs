using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class MedicationIntake
{
    [Key]
    public int MedicationIntakeId { get; set; }
    public int UserId { get; set; }
    public int MedicationId { get; set; }
    public bool Taken { get; set; }
    public required string TypeOfMed { get; set; }
    public DateTime Timestamp { get; set; }

    // Navigation properties
    public required AppUser User { get; set; }
    public required Medication Medication { get; set; }
}
