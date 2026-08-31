using BooksApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

/// <summary>Handles user registration and login.</summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    /// <summary>Initializes the controller with required services.</summary>
    public AuthController( IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>Registers a new user.</summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var (succeeded, errors) = await _authService.RegisterAsync(request.Username, request.Email, request.Password);

        if (!succeeded)
            return BadRequest(errors);

        return Ok("User registered successfully");
    }

    /// <summary>Authenticates a user and returns a JWT on success.</summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var (succeeded, token) = await _authService.LoginAsync(request.Username, request.Password);

        if (!succeeded)
            return Unauthorized("Invalid username or password");

        return Ok(new { token });
    }
}

/// <summary>Register request (username, email, password).</summary>
public record RegisterRequest(string Username, string Email, string Password);

/// <summary>Login request (username, password).</summary>
public record LoginRequest(string Username, string Password);
