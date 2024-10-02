using System;
using System.Data;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class MedicationIntakeRepository(DataContext _context) : IMedicationIntakeRepository
{
    public async Task<MedicationIntake> GetIntakeForMedicationAsync(int medicationId, DateTime date)
    {
        var m = await _context.MedicationIntakes
            .Where(i => i.MedicationId == medicationId && i.Timestamp.Date == date.Date)
            .FirstOrDefaultAsync();
        return m;
    }

    // Create a new intake record
    public async Task CreateMedicationIntakeAsync(MedicationIntake intake)
    {
        await _context.MedicationIntakes.AddAsync(intake); 
    }

    // Save changes to the database
    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
