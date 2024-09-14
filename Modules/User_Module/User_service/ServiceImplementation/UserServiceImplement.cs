using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User_service.Interfaces;
using User_core.Entities;
using User_core.Repository;

namespace User_service.ServiceImplementation
{
    public class UserServiceImplement : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServiceImplement(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
