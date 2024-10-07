using System;
using DataAPI.Models;
using DataAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

	public class AuthController : ControllerBase
	{
		public AuthController()
		{
		}

        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(Person user, string password)
        {
            var newUser = _authService.Register(user, password);
            return Ok(newUser);
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            var token = _authService.Login(username, password);
            if (token == null) return Unauthorized();
            return Ok(new { token });
        }
    }
}

