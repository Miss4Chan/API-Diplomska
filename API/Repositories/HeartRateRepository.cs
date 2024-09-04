using System;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class HeartRateRepository(DataContext _context): IHeartRateRepository
{

    public async Task CreateHeartRateAsync(HeartRate heartRate)
    {
        await _context.HeartRates.AddAsync(heartRate);
        await _context.SaveChangesAsync();
    }

    public async Task CreateHighHeartRateAsync(HighHeartRate highHeartRate)
    {
        await _context.HighHeartRates.AddAsync(highHeartRate);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<HeartRate>> GetRecentHeartRateAsync(int userId, DateTime from, DateTime to)
    {
        return await _context.HeartRates
            .Where(hr => hr.UserId == userId && hr.Timestamp >= from && hr.Timestamp <= to)
            .ToListAsync();
    }
}
