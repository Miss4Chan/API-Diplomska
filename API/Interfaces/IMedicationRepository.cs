using System;
using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IMedicationRepository
{
    Task<bool> CreateMedicationAsync(Medication medication);
    void SoftDeleteMedication(Medication medication);
    Task<IList<MedicationDto>> GetMedicationsByUserAsync(string username);
    Task<IList<MedicationDto>> GetDailyMedicationsByUserAsync(string username);
    Task<Medication> GetMedicationById(int medicationId);
    Task<bool> SaveChanges();
    public Task<IList<Medication>> GetMedicationsForDayAsync(int dayIndex);
}
