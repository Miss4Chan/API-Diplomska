using System;
using API.Entities;
using API.DTOs;

namespace API.Interfaces;

public interface IHeartRateService
{
    Task CreateHeartRateAsync(HeartRateDto heartRateDto, string username);
    Task CreateHighHeartRateAsync(HighHeartRateDto highHeartRateDto, string username);
    Task<IEnumerable<HeartRate>> GetRecentHeartRateAsync(int userId, DateTime from, DateTime to);
}

