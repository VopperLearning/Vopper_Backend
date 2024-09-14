using System;

namespace User_core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? User_Name { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Verificate { get; set; }
    }
}
