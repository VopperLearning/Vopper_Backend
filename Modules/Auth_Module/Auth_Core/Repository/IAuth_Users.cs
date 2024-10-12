using System;
using Auth_Module.Auth_Core.Entitys;

namespace Auth_Module.Auth_Core.Repository
{
    public interface IAuth_Users
    {
        Task<Auth_User> RegisterUser(string UserName, string Password, string Email);
        Task<Auth_User> LoginUser(string UserName, string Password);
        Task<Auth_User> ConfirmEmail(string Email);

    }
}