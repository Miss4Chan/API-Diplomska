using System;

namespace API.DTOs;

public class MedicationDto
{
    public int MedicationId { get; set; }
    public int UserId { get; set; } 
    public required string MedicationName { get; set; }
    public required List<int> RepeatingPattern { get; set; } 
    public bool IsDeleted { get; set; } 

    public required string TimeOfDay { get; set; }
}