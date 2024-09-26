using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class HeartRateRepository(DataContext _context) : IHeartRateRepository
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

    public async Task<IEnumerable<HeartRateDto>> GetRecentHeartRateAsync(string username, DateTime from, DateTime to)
    {
        var appuser = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        if (appuser == null) throw new Exception("Cannot find user");
        var heartRates = await _context.HeartRates
        .Where(hr => hr.UserId == appuser.Id && hr.Timestamp >= from && hr.Timestamp <= to)
        .Select(hr => new HeartRateDto
        {
            Measurement = hr.Measurement,
            Timestamp = hr.Timestamp
        })
        .ToListAsync();

        return heartRates;
    }
}
