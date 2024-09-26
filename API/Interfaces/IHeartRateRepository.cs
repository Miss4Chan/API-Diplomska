using System;
using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IHeartRateRepository
{
    Task CreateHeartRateAsync(HeartRate heartRate);
    Task CreateHighHeartRateAsync(HighHeartRate highHeartRate);
    Task<IEnumerable<HeartRateDto>> GetRecentHeartRateAsync(string username, DateTime from, DateTime to);
}