using System;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Services;

public class MedicationService(IMedicationRepository _medicationRepository,  IUserRepository _userRepository) : IMedicationService
{
    public async Task<bool> CreateMedicationAsync(MedicationDto medicationDto, string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username) ?? throw new Exception("User not found");
        var medication =  new Medication 
        {
            User = user,
            MedicationName = medicationDto.MedicationName,
            RepeatingPattern = medicationDto.RepeatingPattern
        };
        
        await _medicationRepository.CreateMedicationAsync(medication);
        var x = await _medicationRepository.SaveChanges();
        if(x) return true;
        return false;
    }

    public async Task<IList<MedicationDto>> GetDailyMedicationsByUserAsync(string username)
    {
        var m = await _medicationRepository.GetDailyMedicationsByUserAsync(username);
        if(m != null) return m;
        throw new Exception("Error getting data");
    }

    public async Task<IList<MedicationDto>> GetMedicationsByUserAsync(string username)
    {
        var m = await _medicationRepository.GetMedicationsByUserAsync(username);
        if(m != null) return m;
        throw new Exception("Error getting data");
    }

    public async Task<bool> SoftDeleteMedication(int medicationId, string username)
    {
        var medication = await _medicationRepository.GetMedicationById(medicationId) ?? throw new Exception("Cannot get medication");
        _medicationRepository.SoftDeleteMedication(medication);
        var m = await _medicationRepository.SaveChanges();
        if(m) return true;
        throw new Exception("Error deleting medication");
    }
}
