using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FauntasticBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FauntasticBack.Controllers;

[ApiController]
[Route("api/token")]
public class TokenController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TokenController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpPost]
    public IActionResult Post(UserInfo userInfo)
    {
        if (string.IsNullOrWhiteSpace(userInfo.Username))
            return BadRequest();
        
        if (userInfo.Password != _configuration["ApiPassword"]) 
            return Unauthorized();
        
        var claims = new[]
        {
            new Claim("username", userInfo.Username)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: signIn);

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));

    } 
}