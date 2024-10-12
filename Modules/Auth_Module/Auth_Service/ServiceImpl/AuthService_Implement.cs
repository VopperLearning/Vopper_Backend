using System;
using Auth_Module.Auth_Core.Entitys;
using Auth_Module.Auth_Core.Repository;
using Auth_Module.Auth_Service.ServiceInterface;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using Azure.Communication.Email;
using Azure;

namespace Auth_Module.Auth_Service.ServiceImpl
{
    public class AuthService_Implement : IAuthUser_Service
    {
        private readonly IAuth_Users _auth_Users;
        private readonly IConfiguration _configuration;
        private readonly IGenerate_Code _generate_Code;

        public AuthService_Implement(IAuth_Users auth_Users, IConfiguration configuration, IGenerate_Code generate_Code)
        {
            _configuration = configuration;
            _auth_Users = auth_Users;
            _generate_Code = generate_Code;

        }

        public async Task<String> SendConfirmEmail(string Email)
        {


            string connectionString = "endpoint=https://voppermessageservice.unitedstates.communication.azure.com/;accesskey=3tMJLL72EwEGp8pnUe8lUD13iz8Znw4BQjGTlS5RCJfXDRp8DlbwJQQJ99AJACULyCpVPDoZAAAAAZCSrfFK";
            var emailClient = new EmailClient(connectionString);
            var code = _generate_Code.GenerateCode(6);


            var emailMessage = new EmailMessage(
                senderAddress: "DoNotReply@2bb11ee7-186f-4aa5-a7e3-b6e00bb72238.azurecomm.net",
                content: new EmailContent("Correo electrónico de prueba")
                {
                    PlainText = "Hola mundo por correo electrónico.",
                    Html = @"
		<html>
			<body>
				<h1>Bienvenido a Vopper Learnig</h1>
                <p>Para confirmar tu correo electrónico, ingresa el siguiente código: " + code + @"</p>
			</body>
		</html>"
                },
                recipients: new EmailRecipients(new List<EmailAddress> { new EmailAddress(Email) }));


            EmailSendOperation emailSendOperation = emailClient.Send(
                WaitUntil.Completed,
                emailMessage);

            return code;

        }

        public async Task<String> LoginUser(string UserName, string Password)
        {
            var user = await _auth_Users.LoginUser(UserName, Password);

            if (user.Password == Password)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
       {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };


                var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                 issuer: _configuration["Jwt:Issuer"],
                 audience: _configuration["Jwt:Audience"],
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(30),
                 signingCredentials: credentials);

                return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
            };

            return "Invalid User";



        }

        public async Task<Auth_User> RegisterUser(string UserName, string Password, string Email)
        {
            return await _auth_Users.RegisterUser(UserName, Password, Email);
        }

       
        public async Task<Auth_User> ConfirmEmail(string Email)
        {
            return await _auth_Users.ConfirmEmail(Email);
        }
    }
    }

