using System;
using Auth_Module.Auth_Core.Entitys;
using Auth_Module.Auth_Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Auth_Module.Auth_Infraestructure.Persistence.repository
{
    public class AuthRepository : IAuth_Users
    {
        private readonly AuthModelDbContext _context;

        public AuthRepository(AuthModelDbContext context)
        {
            _context = context;
        }

        public async Task<Auth_User> ConfirmEmail(string Email)
        {
            Auth_User user = await _context.Auth_Users
                            .FirstOrDefaultAsync(u => u.Email == Email);

            if (user != null)
            {
                user.IsConfirmed = true;  // Cambiar la propiedad IsConfirmed

                _context.Auth_Users.Update(user);  // Marcar el usuario como actualizado
                await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            }



            return user;
        }

        public async Task<Auth_User> LoginUser(string UserName, string Password)
        {
            Auth_User user = await _context.Auth_Users
                              .FirstOrDefaultAsync(u => u.UserName == UserName);

            return user == null ? new Auth_User() : user;

        }

        public async Task<Auth_User> RegisterUser(string UserName, string Password, string Email)
        {
            Auth_User authUser = new Auth_User
            {
                UserName = UserName,
                Password = Password,
                Email = Email,
                Roles = ["User"]
            };

            await _context.Auth_Users.AddAsync(authUser);

            await _context.SaveChangesAsync();

            return authUser;
        }
    }
}