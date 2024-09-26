using System;
using API.DTOs;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

//[Authorize]
public class HeartRateController(IHeartRateService _heartRateService) : BaseApiController
{
    [HttpPost("createHeartRate")]
    public async Task<ActionResult> CreateHeartRate([FromBody] HeartRateDto heartRateDto)
    {
        var username = User.GetUsername();
        //var username = "string"; // this is for testing purposes 
        await _heartRateService.CreateHeartRateAsync(heartRateDto, username);
        return Ok(new { message = "Heart rate recorded successfully." });
    }

    [HttpPost("createHighHeartRate")]
    public async Task<ActionResult> CreateHighHeartRate([FromBody] HighHeartRateDto highHeartRateDto)
    {
        var username = User.GetUsername();
        //var username = "string"; // this is for testing purposes 
        await _heartRateService.CreateHighHeartRateAsync(highHeartRateDto, username);
        return Ok(new { message = "High heart rate recorded successfully." });
    }

    [HttpGet("getRecentHeartRate")]
    public async Task<ActionResult> GetRecentHeartRate(DateTime from, DateTime to)
    {
        var username = User.GetUsername();
        //var username = "string"; // this is for testing purposes 
        var heartRates = await _heartRateService.GetRecentHeartRateAsync(username, from, to);
        return Ok(heartRates);
    }
    [HttpPost("bulkHeartRate")]
    public async Task<ActionResult> PostBulkHeartRate([FromBody] List<HeartRateDto> heartRates)
    {
        if (heartRates == null || heartRates.Count == 0)
        {
            return BadRequest("No heart rate data provided.");
        }

        try
        {
            var username = User.GetUsername();
            // Assuming you have a service method that handles bulk heart rate saving
            await _heartRateService.SaveBulkHeartRateAsync(heartRates, username);
            return Ok("Heart rate data saved successfully.");
        }
        catch (Exception ex)
        {
            // Log the exception and return an error response
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

}
