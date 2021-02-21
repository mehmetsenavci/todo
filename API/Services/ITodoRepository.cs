using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Services
{
    public interface ITodoRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid userId);
        void CreateUser(User user);
        Task SaveAsync();
        Task UppdateUserAsync(Guid userId, User user);
        void DeleteUser(User user);
        Task<IEnumerable<Todo>> GetAllTodosForUserAsync(Guid userId);
        Task<Todo> GetTodoForUserAsync(Guid userId, Guid todoId);
        Task CreateTodoForUser(User userId, Todo todo);
        Task UpdateTodoForUserAsync(Guid userId, Todo todo);
        Task DeleteTodoForUserAsync(Guid userId, Guid todoId);

    }
}