using Microsoft.AspNetCore.Identity;

namespace BD9.Models
{
    public class User : IdentityUser
    {
        public User(string login, string password)//конструктор для создания пользователей
        {
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(this, password);

            base.Email = login;
            base.UserName = login;
            base.PasswordHash = hashedPassword;
        }
        public User()
        {

        }
    }
}
