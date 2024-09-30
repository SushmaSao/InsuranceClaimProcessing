using IdentityService.Application.Contracts;
using System.Security.Cryptography;

namespace IdentityService.Infrastructure
{
    // Infrastructure Layer
    public class SecurePasswordHelper : IPasswordHasher
    {
        private const int SaltSize = 32;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        public string HashPassword(string password)
        {
            // Generate salt
            byte[] salt = GenerateSalt();
            // Hash password
            byte[] hash = HashPasswordWithSalt(password, salt);
            // Combine salt and hash
            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Split the stored hash into salt and hash
            var parts = hashedPassword.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);
            // Hash the input password with the stored salt
            byte[] hash = HashPasswordWithSalt(password, salt);
            // Compare hashes
            return CompareHashes(hash, storedHash);
        }

        private byte[] GenerateSalt()
        {
            using var rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);
            return salt;
        }

        private byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(HashSize);
        }

        private bool CompareHashes(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length) return false;
            int diff = 0;
            for (int i = 0; i < hash1.Length; i++)
                diff |= hash1[i] ^ hash2[i];
            return diff == 0;
        }
    }

}
