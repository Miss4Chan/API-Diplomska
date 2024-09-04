// using System;
// using Microsoft.AspNetCore.Mvc;

// namespace API.Controllers;

// public class SuddenMovementController : BaseApiController
// {
//     [HttpPost("createSuddenMovement")]
//     public async Task<ActionResult> CreateSuddenMovement([FromBody] SuddenMovementDTO suddenMovementDto)
//     {
//         await _medicationService.CreateSuddenMovementAsync(suddenMovementDto);
//         return Ok(new { message = "Sudden movement recorded successfully." });
//     }
// }
