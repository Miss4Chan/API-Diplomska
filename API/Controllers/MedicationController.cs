using System;
using API.DTOs;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MedicationController(IMedicationService _medicationService) : BaseApiController
{
    [HttpPost("createMedication")]
    public async Task<ActionResult> CreateMedication([FromBody] MedicationDto medicationDto)
    {
        var username = User.GetUsername();
        await _medicationService.CreateMedicationAsync(medicationDto, username);
        return Ok(new { message = "Medication created successfully." });
    }
    [HttpPost("deleteMedication/{medicationId}")]
    public async Task<ActionResult> SoftDeleteMedication(int medicationId)
    {
         var username = User.GetUsername();
        await _medicationService.SoftDeleteMedication(medicationId, username);
        return Ok(new { message = "Medication deleted successfully." });
    }

    [HttpGet("getMedications")]
    public async Task<ActionResult> GetMedications()
    {
        var username = User.GetUsername();
        var medications = await _medicationService.GetMedicationsByUserAsync(username);
        return Ok(medications);
    }
    [HttpGet("getDailyMedications")]
    public async Task<ActionResult> GetDailyMedications()
    {
         var username = User.GetUsername();
        var medications = await _medicationService.GetDailyMedicationsByUserAsync(username);
        return Ok(medications);
    }

}
