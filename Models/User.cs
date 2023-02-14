namespace Pr.Models
{
    public interface IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PasswordConfirmed { get; set; }
        public string Phone { get; set; }
        public bool PhoneConfirmed { get; set; }
    }
    public class User : IUser
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public bool EmailConfirmed { get; set; } = false;
        public bool PasswordConfirmed { get; set; } = false;
        public string? Phone { get; set; } = "";
        public bool PhoneConfirmed { get; set; } = false;
    }
}
