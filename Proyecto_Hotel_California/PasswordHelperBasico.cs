using System;
using System.Security.Cryptography;
using System.Text;

namespace HotelCalifornia
{
    /// <summary>
    /// Helper estático para generar y verificar hashes SHA256.
    /// Implementación educativa sin sal, no apta para producción.
    /// </summary>
    public static class PasswordHelperBasico
    {
        /// <summary>
        /// Calcula un hash SHA256 simple (sin sal) para una contraseña.
        /// </summary>
        /// <param name="password">La contraseña en texto plano.</param>
        /// <returns>Un string de 64 caracteres representando el hash hexadecimal.</returns>
        public static string HashPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder builder = new StringBuilder(hashBytes.Length * 2);
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Verifica una contraseña en texto plano contra un hash SHA256 almacenado.
        /// </summary>
        /// <param name="password">Contraseña ingresada por el usuario (texto plano).</param>
        /// <param name="storedHash">Hash (hexadecimal) almacenado en la BD.</param>
        /// <returns>True si coinciden, false si no.</returns>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (storedHash == null)
                return false;

            string hashOfInput = HashPassword(password ?? string.Empty);
            return string.Equals(hashOfInput, storedHash, StringComparison.Ordinal);
        }
    }
}
