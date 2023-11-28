using TODOLIST.Data.Entites;
using TODOLIST.Data.Models;
using TODOLIST.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TODOLIST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public IUserService _userService;
        public IConfiguration _config;

        public AuthenticateController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsDto credentialsDto)
        {
            //valido usuario
            BaseResponse validateUserResult = _userService.ValidateUser(credentialsDto.Email, credentialsDto.Password);
            if (validateUserResult.Message == "wrong email")
            {
                return BadRequest(validateUserResult.Message);
            }
            else if (validateUserResult.Message == "wrong password")
            {
                return Unauthorized();
            }
            if (validateUserResult.Result)
            {
                //generación del token
                User user = _userService.GetUserByEmail(credentialsDto.Email);
                //crear el token
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //traemos la SecretKey del Json

                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                //Los claims son datos en clave->valor que nos permiten guardar data del usuario.
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.Id.ToString())); //sub es una key estándar (unique user identifier)
                claimsForToken.Add(new Claim("email", user.Email));
                claimsForToken.Add(new Claim("role", user.UserType)); //puede ser "Client", "Admin" o "SuperAdmin"

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
            return BadRequest();
        }
    }
}
