using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User_Module.User_core.Entities;

namespace User_Module.User_service.ServiceInterface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);

    }
}
