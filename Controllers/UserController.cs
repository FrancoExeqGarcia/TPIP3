using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;
using TODOLIST.Enums;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetProgramers()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            string loggedUserEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            User userLogged = _userService.GetUserByEmail(loggedUserEmail);

            if (role == "Admin" || role == "SuperAdmin" && userLogged.State)
            {
                return Ok(_userService.GetUsersByRole("Client"));
            }
            return Forbid();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateProgramer([FromBody] ProgramerPostDto programerPostDto) //sería la registración de un nuevo cliente
        {
            if (!_userService.CheckIfUserExists(programerPostDto.Email))
            {
                Programer programer = new Programer()
                {
                    Email = programerPostDto.Email,
                    Password = programerPostDto.Password,
                    UserName = programerPostDto.UserName,
                };
                int id = _userService.CreateUser(programer);
                return Ok(id);
            }
            else
            {
                return BadRequest("Client already exists");
            }
        }

        [HttpPost("admin/")]
        public IActionResult CreateAdmin([FromBody] AdminPostDto adminPostDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role == "SuperAdmin")
            {
                Admin admin = new Admin()
                {
                    Email = adminPostDto.Email,
                    Password = adminPostDto.Password,
                    UserName = adminPostDto.UserName,
                    UserType = nameof(UserRoleEnum.Admin)
                };
                int id = _userService.CreateUser(admin);
                return Ok(id);
            }
            return Forbid();
        }

        [HttpPut]
        public IActionResult UpdateProgramer([FromBody] ProgramerUpdateDto programerUpdateDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role == "Programer")
            {
                Programer programerToUpdate = new Programer()
                {
                    UserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    UserName = programerUpdateDto.UserName,
                    Password = programerUpdateDto.Password,
                };
                _userService.UpdateUser(programerToUpdate);
                return Ok();
            }
            return Forbid();
        }

        [HttpDelete]
        public IActionResult DeleteSelfUser() //usuario se borre a sí mismo
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _userService.DeleteUser(id); //borrado lógico (el usuario seguirá en la base de datos)
            return NoContent();
        }
    }
}