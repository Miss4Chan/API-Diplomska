using System;

namespace API.DTOs;

public class HighHeartRateDto
{
    public DateTime Timestamp { get; set; }
    public double Measurement { get; set; }
    public bool? Confirm { get; set; }
    public DateTime? TimeOfConfirmation { get; set; }
}
