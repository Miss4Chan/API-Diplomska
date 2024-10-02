using System;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace API.Services;

public class MedicationIntakeService(IUserRepository _userRepository
, IMedicationIntakeRepository _medicationIntakeRepository,
IMedicationRepository _medicationRepository) : IMedicationIntakeService
{
    public async Task CreateMedicationIntakesForAllUsersAsync()
    {
       var todayIndex = (int)DateTime.Today.DayOfWeek;

            var medications = await _medicationRepository.GetMedicationsForDayAsync(todayIndex);

            foreach (var medication in medications)
            {
                var existingIntake = await _medicationIntakeRepository.GetIntakeForMedicationAsync(medication.MedicationId, DateTime.Today);

                if (existingIntake == null)
                {
                    var intake = new MedicationIntake
                    {
                        User = await _userRepository.GetUserByUserIdAsync(medication.UserId),
                        MedicationId = medication.MedicationId,
                        Name = medication.MedicationName,
                        Medication = medication,
                        Taken = false, 
                        Timestamp = DateTime.Now
                    };

                    await _medicationIntakeRepository.CreateMedicationIntakeAsync(intake);
                }
            }

            // Save all changes to the database
            await _medicationIntakeRepository.SaveChanges();
    }

    public async Task<bool> MarkMedicationIntakeForUserAsync(MedicationIntakeDto intakeDto, string username)
    {
        // Step 1: Get the user based on the username
        var user = await _userRepository.GetUserByUsernameAsync(username) ?? throw new Exception("User not found");

        // Step 2: Get the medication by its ID
        var medication = await _medicationRepository.GetMedicationById(intakeDto.MedicationId) ?? throw new Exception("Medication not found");

        // Step 3: Check if the medication belongs to the user
        if (medication.UserId != user.Id)
        {
            throw new Exception("User does not have access to this medication.");
        }

        // Step 4: Create a new MedicationIntake record for the user
        var intake = new MedicationIntake
        {
            User = user,
            Name = medication.MedicationName,
            Medication = medication,
            MedicationId = medication.MedicationId,
            Taken = (bool)intakeDto.Taken,
            Timestamp = (DateTime)intakeDto.Timestamp
        };

        // Step 5: Use the repository to save the intake record
        await _medicationIntakeRepository.CreateMedicationIntakeAsync(intake);

        return await _medicationIntakeRepository.SaveChanges();
    }


}
