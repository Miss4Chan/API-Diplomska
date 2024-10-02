using System;
using API.Entities;

namespace API.Interfaces;

public interface IMedicationIntakeRepository
{
    Task<MedicationIntake> GetIntakeForMedicationAsync(int medicationId, DateTime date);
    Task CreateMedicationIntakeAsync(MedicationIntake intake); 
    Task<bool> SaveChanges();
}
