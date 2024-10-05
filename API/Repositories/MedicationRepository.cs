using System;
using System.Transactions;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class MedicationRepository(DataContext _context) : IMedicationRepository
{
    public async Task<bool> CreateMedicationAsync(Medication medication)
    {
        var a = await _context.Medications.AddAsync(medication);
        if (a != null) return true;
        throw new Exception("Cannot create medication");
    }

    public async Task<IList<MedicationDto>> GetDailyMedicationsByUserAsync(string username)
    {
        var user = await _context.Users
         .Include(u => u.Medications)
         .ThenInclude(m => m.MedicationIntakes)
         .Where(u => u.Username == username)
         .FirstOrDefaultAsync() ?? throw new Exception("User not found");

        if (user.Medications == null) throw new Exception("No medications for this user");

        // Get today's index (0 = Sunday, 6 = Saturday)
        var todayIndex = (int)DateTime.Today.DayOfWeek;

        // Filter for daily medications
        var dailyMeds = user.Medications
        .Where(m => m.RepeatingPattern[todayIndex] == 1 && !m.IsDeleted)
        .Where(m => m.MedicationIntakes == null || !m.MedicationIntakes.Any(mi => mi.Timestamp.Date == DateTime.Today))
        .Select(m => new MedicationDto
        {
            MedicationId = m.MedicationId,
            MedicationName = m.MedicationName,
            RepeatingPattern = m.RepeatingPattern,
            TimeOfDay = m.TimeOfDay.ToString("HH:mm") // Convert TimeOnly to string
        })
        .ToList();


        return dailyMeds;
    }


    public async Task<Medication> GetMedicationById(int medicationId)
    {
        var m = await _context.Medications
        .Where(m => m.MedicationId == medicationId && !m.IsDeleted)
        .FirstOrDefaultAsync();
        if (m != null) return m;
        throw new Exception("Cannot get medication");
    }

    public async Task<IList<MedicationDto>> GetMedicationsByUserAsync(string username)
    {
        var user = await _context.Users
       .Include(u => u.Medications)
       .Where(u => u.Username == username)
       .FirstOrDefaultAsync() ?? throw new Exception("User not found");
        if (user.Medications == null) throw new Exception("No medications for this user");

        var meds = user.Medications
            .Where(m => !m.IsDeleted) // Only fetch medications that are not deleted
            .Select(m => new MedicationDto
            {
                MedicationId = m.MedicationId,
                MedicationName = m.MedicationName,
                RepeatingPattern = m.RepeatingPattern,
                TimeOfDay = m.TimeOfDay.ToString("HH:mm")
            })
            .ToList();

        return meds;
    }

    public void SoftDeleteMedication(Medication medication)
    {
        medication.IsDeleted = true;
    }

    public async Task<bool> SaveChanges()
    {
        var x = await _context.SaveChangesAsync();
        if (x <= 0) throw new Exception("Cannot save changes");
        return true;
    }
    public async Task<IList<Medication>> GetMedicationsForDayAsync(int dayIndex)
    {
        return await _context.Medications
            .Include(m => m.MedicationIntakes)
            .Where(m => m.RepeatingPattern[dayIndex] == 1 && !m.IsDeleted)
            .ToListAsync();
    }

}
