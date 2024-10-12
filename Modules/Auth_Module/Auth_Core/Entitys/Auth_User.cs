using System;


namespace Auth_Module.Auth_Core.Entitys
{
    public class Auth_User
    {
        public Auth_User()
        {
        }

        public Auth_User(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Id = 0;
            IsConfirmed = false;
            Roles = new string[] { "User" };
        }

          public Auth_User(string userName, string password, string email, string[] roles)
        {
            Id = 0;
            UserName = userName;
            Password = password;
            Email = email;
            Roles = roles;
            IsConfirmed = false;
        }

           public Auth_User(string userName, string password)
        {
            Id = 0;
            UserName = userName;
            Password = password;
            Email = "";
            Roles = new string[] { "User" };
            IsConfirmed = false;
        }




        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Boolean IsConfirmed { get; set; }

        public string[] Roles { get; set; }

    }
}