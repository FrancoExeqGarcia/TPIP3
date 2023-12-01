﻿using ErrorOr;
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


        
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult CreateProgramer([FromBody] ProgramerPostDto programerPostDto) //sería la registración de un nuevo cliente
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "SuperAdmin")
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
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Client already exists");
                }
            }
            return Forbid();
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
                return Ok(result);
            }
            return Forbid();
        }


        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult UpdateProgramer(int userId, [FromBody] ProgramerUpdateDto programerUpdateDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "SuperAdmin")
            {
                    var updatedProgramer = new Programer
                {
                    Email = programerUpdateDto.Email,
                    UserName = programerUpdateDto.UserName,
                    Password = programerUpdateDto.Password,
                };
                try
                {
                    var result = _userService.UpdateUser(userId, updatedProgramer);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "SuperAdmin")
            {
                    try
                    {
                    _userService.DeleteUser(id);
                    return NoContent(); // Devuelve 204 No Content si la eliminación fue exitosa
                    }
                catch (Exception ex)
                    {
                    return StatusCode(500, "Internal Server Error"); // Devuelve 500 Internal Server Error en caso de una excepción no manejada
                 }
            }
            return Forbid();
        }


    }
}