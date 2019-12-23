using BeierSeguros.Domain.Core;
using BeierSeguros.Shared.Entities;

namespace BeierSeguros.Domain.Users.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(string name, string password, string email)
        {
            Name = name;
            Password = PasswordHasher.Generate(password);
            Email = email;
        }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public string Email { get; private set; }
    }
}