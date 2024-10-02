using System;
using API.DTOs;

namespace API.Interfaces;

public interface IMedicationIntakeService
{
    public Task<bool> MarkMedicationIntakeForUserAsync(MedicationIntakeDto intakeDto, string username);
    public Task CreateMedicationIntakesForAllUsersAsync();
}
