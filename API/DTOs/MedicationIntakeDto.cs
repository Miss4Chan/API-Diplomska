using System;

namespace API.DTOs;

public class MedicationIntakeDto
{
    public int MedicationId { get; set; }
    public bool? Taken { get; set; }
    public DateTime? Timestamp { get; set; }

}
