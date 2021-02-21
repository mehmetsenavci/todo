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
        public async Task<IActionResult> CreateUser(UserForCreationDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var userEntity = _mapper.Map<UserForCreationDto, User>(user);
            _repo.CreateUser(userEntity);
            await _repo.SaveAsync();

            return CreatedAtAction("GetUser", new { userId = userEntity.UserId }, userEntity);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAllUsers()
        {
            var usersFromRepo = await _repo.GetAllUsersAsync();
            
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(usersFromRepo));
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(Guid userId)
        {
            var userFromRepo = await _repo.GetUserAsync(userId);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<User, UserDto>(userFromRepo));
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser(Guid userId, UserForFullUpdateDto user)
        {
            var userFromRepo = await _repo.GetUserAsync(userId);
            if (userFromRepo == null)
            {
                return NoContent();
            }
            _mapper.Map(user, userFromRepo);
            await _repo.SaveAsync();

            return NoContent();

        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var userFromRepo = await _repo.GetUserAsync(userId);
            if (userId == null) 
            {
                return NotFound();
            }

            _repo.DeleteUser(userFromRepo);
            await _repo.SaveAsync();
            return NoContent();
        }
    }
}