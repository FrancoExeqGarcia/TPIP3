using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;
using TODOLIST.Enums;
using TODOLIST.Services.Implementations;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Project>> Get(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
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
                int id = _userService.CreateUser(programer).Value;
                return Ok(id);
            }
            else
            {
                return BadRequest("Client already exists");
            }
        }

        [HttpPost("admin/")]
        [Authorize(Roles = "SuperAdmin")]

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

        /*[HttpPut]
        public IActionResult UpdateProgramer(int userId, [FromBody] ProgramerUpdateDto programerUpdateDto)
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
        }*/

        [HttpPut]
        public IActionResult UpdateProgramer(int userId, [FromBody] ProgramerUpdateDto programerUpdateDto)
        {
            var updatedProgramer = new Programer
            {
                UserId = userId,
                UserName = programerUpdateDto.UserName,
                Password = programerUpdateDto.Password,
            };

            try
            {
                _userService.UpdateUser(updatedProgramer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent(); // Devuelve 204 No Content si la eliminación fue exitosa
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error"); // Devuelve 500 Internal Server Error en caso de una excepción no manejada
            }
        }


    }
}