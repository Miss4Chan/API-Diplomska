using System;
using API.DTOs;

namespace API.Interfaces;

public interface ISuddenMovementService
{
    public Task CreateSuddenMovementsync(SuddenMovementDto suddenMovementDto, string username);
}
