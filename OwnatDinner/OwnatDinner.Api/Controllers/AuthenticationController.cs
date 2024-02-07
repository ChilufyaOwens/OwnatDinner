using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OwnatDinner.Application.Services.Authentication;
using OwnatDinner.Contracts.Authentication;

namespace OwnatDinner.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authResult.Id, 
                authResult.FirstName, 
                authResult.LastName, 
                authResult.Email, 
                authResult.Token);

            return Ok(response);
                
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);

            return Ok(response);
        }
    }
}
