using Card.Application.Contracts;
using Card.Presentation.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationServices authenticationServices) : ControllerBase
{   
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        var result = authenticationServices.Login(loginRequest.Login,loginRequest.Senha);
        if (!string.IsNullOrEmpty(result))
        {
            return Ok(result);
        }return BadRequest();     

    } 
}


