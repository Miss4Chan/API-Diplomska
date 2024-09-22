using System;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Services;

public class SuddenMovementService(ISuddenMovementRepository _suddenMovementRepository, IUserRepository _userRepository) : ISuddenMovementService
{
    public async Task CreateSuddenMovementsync(SuddenMovementDto suddenMovementDto, string username)
    {var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var suddenMovement = new SuddenMovement
        {
           Confirm = suddenMovementDto.Confirm,
           TimeOfConfirmation = suddenMovementDto.TimeOfConfirmation,
           Timestamp = suddenMovementDto.Timestamp,
           User = user
        };

        await _suddenMovementRepository.CreateSuddenMovementAsync(suddenMovement);
    }
}
