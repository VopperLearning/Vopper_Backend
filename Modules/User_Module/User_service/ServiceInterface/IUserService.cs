using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User_core.Entities;

namespace User_service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(long id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(long id);

    }
}
