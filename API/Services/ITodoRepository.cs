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
        Task<Todo> GetTodoForUserAsync(User user, Guid todoId);
        void CreateTodoForUser(User user, Todo todo);
        Task UpdateTodoForUserAsync(Guid userId, Todo todo);
        Task DeleteTodoForUserAsync(Guid userId, Guid todoId);

    }
}