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


        [HttpGet("User/")]
        public IActionResult GetUser()
        {
            string loggedUserEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            User? user = _userService.GetUserByEmail(loggedUserEmail);

            if (user != null && user.State)
            {
                UserDto userDto = new UserDto()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    UserType = user.UserType
                };
                return Ok(userDto);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            string loggedUserEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            User userLogged = _userService.GetUserByEmail(loggedUserEmail);

            if (role == "Admin" || role == "SuperAdmin" && userLogged.State)
            {
                return Ok(_userService.GetUsersByRole("Client").Value);
            }
            return Forbid();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateProgramer([FromBody] ProgramerPostDto clientPostDto) //sería la registración de un nuevo cliente
        {
            if (!_userService.CheckIfUserExists(clientPostDto.Email))
            {
                Programer programer = new Programer()
                {
                    Email = clientPostDto.Email,
                    Password = clientPostDto.Password,
                    UserName = clientPostDto.UserName,
                };
                int id = _userService.CreateUser(programer).Value;
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
                int id = _userService.CreateUser(admin).Value;
                return Ok(id);
            }
            return Forbid();
        }

        [HttpPut]
        public IActionResult UpdateProgramer([FromBody] ProgramerUpdateDto clientUpdateDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role == "Programer")
            {
                Programer programerToUpdate = new Programer()
                {
                    UserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    UserName = clientUpdateDto.UserName,
                    Password = clientUpdateDto.Password,
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