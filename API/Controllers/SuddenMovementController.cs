using System;
using API.DTOs;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SuddenMovementController(ISuddenMovementService _suddenMovementService) : BaseApiController
{
    [HttpPost("createSuddenMovement")]
    public async Task<ActionResult> CreateSuddenMovement([FromBody] SuddenMovementDto suddenMovementDto)
    {
        var username = User.GetUsername();
        //var username = "string";
        await _suddenMovementService.CreateSuddenMovementsync(suddenMovementDto, username);
        return Ok(new { message = "Sudden movement recorded successfully." });
    }
}
