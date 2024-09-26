using System;
using API.Entities;
using API.DTOs;

namespace API.Interfaces;

public interface IHeartRateService
{
    Task CreateHeartRateAsync(HeartRateDto heartRateDto, string username);
    Task SaveBulkHeartRateAsync(List<HeartRateDto> heartRate, string username);
    Task CreateHighHeartRateAsync(HighHeartRateDto highHeartRateDto, string username);
    Task<IEnumerable<HeartRateDto>> GetRecentHeartRateAsync(string username, DateTime from, DateTime to);
}

