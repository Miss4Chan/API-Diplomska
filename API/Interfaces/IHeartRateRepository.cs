using System;
using API.Entities;

namespace API.Interfaces;

public interface IHeartRateRepository
{
    Task CreateHeartRateAsync(HeartRate heartRate);
    Task CreateHighHeartRateAsync(HighHeartRate highHeartRate);
    Task<IEnumerable<HeartRate>> GetRecentHeartRateAsync(int userId, DateTime from, DateTime to);
}