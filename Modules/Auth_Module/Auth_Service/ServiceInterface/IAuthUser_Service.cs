using System;
using Auth_Module.Auth_Core.Entitys;

namespace Auth_Module.Auth_Service.ServiceInterface
{
    public interface IAuthUser_Service
    {
       public Task<Auth_User> RegisterUser(string UserName, string Password, string Email);
       public Task<String> LoginUser(string UserName, string Password);
       public Task<String> SendConfirmEmail(string Email);
       public Task <Auth_User> ConfirmEmail(string Email);

    }
}