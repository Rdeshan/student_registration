using System;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Application.Interfaces;
using StudentRegistration.Domain.Entities;


namespace student_registration.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService )
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Email and password are required");

            var loggedInUser = await _authService.ValidateUserAsync(user.Email, user.Password);

            if (loggedInUser == null)
                return Unauthorized("Invalid email or password");

            return Ok(loggedInUser);

        }

        [HttpPost("Create")]
        public async Task<IActionResult> RegisterAdmin([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("enter valid values");
            }

            var isSuccess = await _authService.RegisterUserAsync(user);
            if (isSuccess)
            {
                return Ok(user);
            }

        return BadRequest("could not register the admin");

        }

    }

        
}
