﻿using BulbEd.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

/*
 * This controller is used for testing purposes NO PRODUCTION CODE SHOULD BE HERE
 */
public class TestController : BaseApiController
{
    
    private readonly IEmailSender _emailSender;
    
    public TestController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost("sendemail")]
    public async Task<ActionResult> SendEmail()
    {
        await _emailSender.SendEmailAsync("juantrevi70@gmail.com", "Test email", "This is a test email");

        return Ok();
    }
}