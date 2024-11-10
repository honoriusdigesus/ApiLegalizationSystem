using System.Security.Cryptography;
using System.Text;

namespace ApiLegalizationSystem.Domain.Utils
{
    public class Helpper
    {
        //Encrypt the password 
        public string EncryptPassword(string token)
        {
            using SHA256 sha256Hash = SHA256.Create();
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(token)); // Convertir el token a bytes
            var builder = new StringBuilder(); // Crear un string builder
            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2")); // Convertir los bytes a string
            }
            return builder.ToString(); // Retornar el string encriptado
        }
    }
}
