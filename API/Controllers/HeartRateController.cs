using System;
using API.DTOs;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class HeartRateController(IHeartRateService _heartRateService) : BaseApiController
{
    [HttpPost("createHeartRate")]
    public async Task<ActionResult> CreateHeartRate([FromBody] HeartRateDto heartRateDto)
    {
        var username = User.GetUsername();
        await _heartRateService.CreateHeartRateAsync(heartRateDto, username);
        return Ok(new { message = "Heart rate recorded successfully." });
    }

    [HttpPost("createHighHeartRate")]
    public async Task<ActionResult> CreateHighHeartRate([FromBody] HighHeartRateDto highHeartRateDto)
    {
        var username = User.GetUsername();
        await _heartRateService.CreateHighHeartRateAsync(highHeartRateDto, username);
        return Ok(new { message = "High heart rate recorded successfully." });
    }

    [HttpGet("getRecentHeartRate")]
    public async Task<ActionResult> GetRecentHeartRate(DateTime from, DateTime to)
    {
        var userId = User.GetUserId();
        var heartRates = await _heartRateService.GetRecentHeartRateAsync(userId, from, to);
        return Ok(heartRates);
    }
}
