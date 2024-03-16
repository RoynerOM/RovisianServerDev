using RovisianServerDev.Domain.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace RovisianServerDev.Domain.Services
{

    public class PasswordService : IPasswordService
    {
        public string Hash(string password, byte[] salt)
        {
            byte[] hash = Encoding.UTF8.GetBytes(password);

            using Rfc2898DeriveBytes pbkdf2 = new(CalculateSHA256(hash), salt, 10000, HashAlgorithmName.SHA512);

            return Convert.ToBase64String(pbkdf2.GetBytes(32));
        }

        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];

            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            return salt;
        }
        public bool Verify(string passwordEntered, string storedHashed, byte[] salt)
        {
            string hashedEnteredPassword = Hash(passwordEntered, salt);

            byte[] hashEnteredBytes = Convert.FromBase64String(hashedEnteredPassword);
            byte[] storedHashBytes = Convert.FromBase64String(storedHashed);

            return MatchByteArrays(hashEnteredBytes, storedHashBytes);
        }

        private static bool MatchByteArrays(byte[] a, byte[] b)
        {
            // Comprueba si los arreglos tienen la misma longitud.
            if (a.Length != b.Length) return false;

            // Variable para registrar cualquier diferencia entre los bytes en los arreglos.
            int result = 0;

            for (var i = 0; i < a.Length; i++)
            {
                // Realiza una operación XOR entre los bytes en las posiciones i de los arreglos a y b.
                // Esto establecerá bits en result donde haya diferencias entre los bytes.
                result |= a[i] ^ b[i];
            }

            // Si no se encontraron diferencias entre los bytes, result será 0.
            return result == 0;
        }

        private static byte[] CalculateSHA256(byte[] bytes)
        {
            using SHA256 sha256 = SHA256.Create();

            return sha256.ComputeHash(bytes);
        }
    }
}
