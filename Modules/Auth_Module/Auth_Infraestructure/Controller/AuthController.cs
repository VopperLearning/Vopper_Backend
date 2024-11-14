using Auth_Module.Auth_Core.Entitys;
using Auth_Module.Auth_Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auth_Module.Auth_Infraestructure.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUser_Service _authUser_Service;
        public AuthController(IAuthUser_Service authUser_Service)
        {
            _authUser_Service = authUser_Service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(string UserName, string Password, string Email)
        {
            Auth_User user = await _authUser_Service.RegisterUser(UserName, Password, Email);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(string UserName, string Password)
        {

            var response  = await _authUser_Service.LoginUser(UserName, Password);
            return Ok(response);
        }

        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string Email)
        {
            Auth_User user = await _authUser_Service.ConfirmEmail(Email);
            return Ok(user);
        }
        
        [HttpPost("SendConfirmEmail")]
        public async Task<IActionResult> SendConfirmEmail(string Email)
        {
            string code = await _authUser_Service.SendConfirmEmail(Email);
            return Ok(code);
        }
        
    }
}