using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CreateTodoForUser(User user, Todo todo)
        {
            _context.Todos.Add(todo);
            user.Todos.Add(todo);
        }

        public void CreateUser(User user)
        {
            _context.Add(user);
        }

        public void DeleteTodoForUserAsync(Todo todo)
        {
            _context.Todos.Remove(todo);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<Todo>> GetAllTodosForUserAsync(User user)
        {
            return await _context.Entry(user).Collection(u => u.Todos).Query().ToListAsync();
                                    
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Todo> GetTodoForUserAsync(User user, Guid todoId)
        {
            return await _context.Entry(user).Collection(u => u.Todos)
                                    .Query().Where(u => u.TodoId == todoId).FirstOrDefaultAsync();
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