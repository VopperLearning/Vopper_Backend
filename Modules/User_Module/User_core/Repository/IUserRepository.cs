using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_core.Entities;

namespace User_core.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    } 
}
