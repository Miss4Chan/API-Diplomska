using System;

namespace API.DTOs;

public class SuddenMovementDto
{
    public DateTime Timestamp { get; set; }
    public bool? Confirm { get; set; }
    public DateTime? TimeOfConfirmation { get; set; }
}
