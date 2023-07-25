using CourseZone.Service.Dtos.Notifications;
using CourseZone.Service.Interfaces.Notifcations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseZone.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailSender _smsSender;
    public EmailController(IEmailSender smsSender)
    {
        this._smsSender = smsSender;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SendAsync([FromBody] EmailMessage smsMessage)
    {
        return Ok(await _smsSender.SendAsync(smsMessage));
    }
}
