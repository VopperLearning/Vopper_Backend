using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Module.User_core.Entities;
using User_Module.User_core.Repository;

namespace User_Module.User_infraestructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        //TODO: Inject the context
        private readonly UserDBContext Context;

        //TODO: Implement the interfaces
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
