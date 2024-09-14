using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User_Module.User_service.ServiceInterface;
using User_Module.User_core.Entities;
using User_Module.User_core.Repository;

namespace User_Module.User_service.ServiceImplementation
{
    public class UserServiceImplement : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServiceImplement(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //TODO: Implement the rest of the methods
        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
