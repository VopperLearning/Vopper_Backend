using System;

namespace User_Module.User_core.Entities
{
    public class User
    {
        public Guid Id { get; set; } // UUID
        public string? User_Name { get; set; }
        public string? Firs_tName { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Verificate { get; set; }
    }
}
