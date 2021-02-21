using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repo; 
        private readonly IMapper _mapper;
        public TodoController(ITodoRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _repo.CreateUser(user);
            await _repo.SaveAsync();

            return CreatedAtAction("GetUser", new { userId = user.UserId }, user);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            var usersFromRepo = await _repo.GetAllUsersAsync();
            
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(usersFromRepo));
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUser(Guid userId)
        {
            var userFromRepo = await _repo.GetUserAsync(userId);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<User, UserDto>(userFromRepo));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var userFromRepo = await _repo.GetUserAsync(userId);
            if (userId == null) 
            {
                return NotFound();
            }

            _repo.DeleteUserAsync(userFromRepo);
            await _repo.SaveAsync();
            return NoContent();
        }
    }
}