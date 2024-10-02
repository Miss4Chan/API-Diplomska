using System;
using API.DTOs;

namespace API.Interfaces;

public interface IMedicationService
{
    Task<bool> CreateMedicationAsync(MedicationDto medicationDto, string username);
    Task<bool> SoftDeleteMedication(int medicationId, string username);
    Task<IList<MedicationDto>> GetMedicationsByUserAsync(string username);
    Task<IList<MedicationDto>> GetDailyMedicationsByUserAsync(string username);
}
