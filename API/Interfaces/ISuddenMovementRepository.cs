using System;
using API.Entities;

namespace API.Interfaces;

public interface ISuddenMovementRepository
{
     Task CreateSuddenMovementAsync(SuddenMovement suddenMovement);
}
