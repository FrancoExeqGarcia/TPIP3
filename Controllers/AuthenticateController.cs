using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TODOLIST.Data.Entities;
using TODOLIST.Services.Interfaces;
using TODOLIST.Data.Models;

namespace TODOLIST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AuthenticateController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsDto credentialsDto)
        {
            if (credentialsDto == null)
            {
                return BadRequest("Invalid credentials");
            }

            // Validar usuario
            BaseResponse validateUserResult = _userService.ValidateUser(credentialsDto.Email, credentialsDto.Password);

            if (validateUserResult.Message == "wrong email")
            {
                return BadRequest("Invalid email");
            }
            else if (validateUserResult.Message == "wrong password")
            {
                return Unauthorized("Invalid password");
            }

            if (validateUserResult.Result)
            {
                // Obtener información del usuario directamente como UserDto
                UserDto userDto = _userService.GetUserByEmail(credentialsDto.Email);

                // Crear el token
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>
        {
            //new Claim("sub", userDto.UserId.ToString()),
            new Claim("email", userDto.Email),
            new Claim("role", userDto.UserType)
        };

                var jwtSecurityToken = new JwtSecurityToken(
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }

            return BadRequest("Invalid credentials");
        }


    }
}
