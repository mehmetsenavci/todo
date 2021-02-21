using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Context;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TodoRepository : ITodoRepository
    {
        public TodoContext _context { get; }
        public TodoRepository(TodoContext context)
        {
            _context = context;

        }
        public Task CreateTodoForUser(User userId, Todo todo)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user)
        {
            _context.Add(user);
        }

        public Task DeleteTodoForUserAsync(Guid userId, Guid todoId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public Task<IEnumerable<Todo>> GetAllTodosForUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<Todo> GetTodoForUserAsync(Guid userId, Guid todoId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateTodoForUserAsync(Guid userId, Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task UppdateUserAsync(Guid userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}