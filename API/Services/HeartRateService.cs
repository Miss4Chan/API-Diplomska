using System;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using SQLitePCL;

namespace API.Services;

public class HeartRateService(IHeartRateRepository _heartRateRepository, IUserRepository _userRepository) : IHeartRateService
{

   public async Task CreateHeartRateAsync(HeartRateDto heartRateDto, string username)
    {
        // Get the user from the database based on the username
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var heartRate = new HeartRate
        {
            Measurement = heartRateDto.Measurement,
            Timestamp = heartRateDto.Timestamp,
            User = user // Set the user object here
        };

        await _heartRateRepository.CreateHeartRateAsync(heartRate);
    }

    public async Task CreateHighHeartRateAsync(HighHeartRateDto highHeartRateDto, string username)
    {
        // Get the user from the database based on the username
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var highHeartRate = new HighHeartRate
        {
            Confirm = highHeartRateDto.Confirm,
            Measurement = highHeartRateDto.Measurement,
            TimeOfConfirmation = highHeartRateDto.TimeOfConfirmation,
            Timestamp = highHeartRateDto.Timestamp,
            User = user
        };

        await _heartRateRepository.CreateHighHeartRateAsync(highHeartRate);
    }

    public async Task<IEnumerable<HeartRateDto>> GetRecentHeartRateAsync(string username, DateTime from, DateTime to)
    {
        return await _heartRateRepository.GetRecentHeartRateAsync(username, from, to);
    }

    public async Task SaveBulkHeartRateAsync(List<HeartRateDto> heartRates,string username)
    {
        foreach(HeartRateDto h in heartRates)
        {
            await CreateHeartRateAsync(h,username);
        }
    }
}

