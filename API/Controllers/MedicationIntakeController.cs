using System;
using API.DTOs;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MedicationIntakeController(IMedicationIntakeService _medicationIntakeService) : BaseApiController
{
    [HttpPost("mark-intake")]
    public async Task<IActionResult> MarkMedicationIntake([FromBody] MedicationIntakeDto intakeDto)
    {
        // Get the authenticated user's username from the claims
        var username = User.GetUsername();

        try
        {
            // Mark the medication intake using the service
            var result = await _medicationIntakeService.MarkMedicationIntakeForUserAsync(intakeDto, username);

            if (result)
            {
                return Ok(new { message = "Medication intake recorded successfully." });
            }
            else
            {
                return BadRequest(new { message = "Failed to record medication intake." });
            }
        }
        catch (Exception ex)
        {
            // Return an error response if something goes wrong
            return BadRequest(new { message = ex.Message });
        }
    }
}
