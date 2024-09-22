using System;
using API.Data;
using API.Entities;

namespace API.Interfaces;

public class SuddenMovementRepository(DataContext _context) : ISuddenMovementRepository
{
    public async Task CreateSuddenMovementAsync(SuddenMovement suddenMovement)
    {
        await _context.SuddenMovements.AddAsync(suddenMovement);
        await _context.SaveChangesAsync();
    }
}
