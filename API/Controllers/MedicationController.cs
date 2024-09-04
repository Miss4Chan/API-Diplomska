// using System;
// using Microsoft.AspNetCore.Mvc;

// namespace API.Controllers;

// public class MedicationController : BaseApiController
// {
//     [HttpPost("createMedication")]
//     public async Task<ActionResult> CreateMedication([FromBody] MedicationDTO medicationDto)
//     {
//         await _medicationService.CreateMedicationAsync(medicationDto);
//         return Ok(new { message = "Medication created successfully." });
//     }

//     [HttpGet("getMedicationById/{id}")]
//     public async Task<ActionResult> GetMedicationById(int id)
//     {
//         var medication = await _medicationService.GetMedicationByIdAsync(id);
//         return Ok(medication);
//     }

//     [HttpGet("getMedications")]
//     public async Task<ActionResult> GetMedications()
//     {
//         var userId = GetUserIdFromClaims(); // Method to get userId from claims
//         var medications = await _medicationService.GetMedicationsByUserAsync(userId);
//         return Ok(medications);
//     }

//     [HttpGet("getMedicationIntake/{id}")]
//     public async Task<ActionResult> GetMedicationIntake(int id)
//     {
//         var intake = await _medicationService.GetMedicationIntakeByIdAsync(id);
//         return Ok(intake);
//     }

//     [HttpGet("getMedicationIntakePerMed/{medicationId}")]
//     public async Task<ActionResult> GetMedicationIntakePerMed(int medicationId)
//     {
//         var intakes = await _medicationService.GetMedicationIntakeByMedicationIdAsync(medicationId);
//         return Ok(intakes);
//     }

//     [HttpPost("createMedicationIntake")]
//     public async Task<ActionResult> CreateMedicationIntake([FromBody] MedicationIntakeDTO intakeDto)
//     {
//         await _medicationService.CreateMedicationIntakeAsync(intakeDto);
//         return Ok(new { message = "Medication intake recorded successfully." });
//     }

//     private int GetUserIdFromClaims()
//     {
//         return int.Parse(User.Claims.First(c => c.Type == "id").Value); // Adjust based on your JWT claims
//     }
// }
