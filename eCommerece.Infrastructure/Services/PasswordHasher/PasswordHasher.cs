using eCommerece.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace eCommerece.Infrastructure.Services.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashedPassword(string password)
        {
            var hashedPassword = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
