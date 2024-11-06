using System.Security.Cryptography;
using System.Text;

namespace ApiLegalizationSystem.Domain.Utils
{
    public class Helpper
    {
        //Encrypt the password 
        public string encryptTokenSHA256(string token)
        {
            using (SHA256 SHA256Hash = SHA256.Create())
            {
                byte[] bytes = SHA256Hash.ComputeHash(Encoding.UTF8.GetBytes(token)); // Convertir el token a bytes
                StringBuilder builder = new StringBuilder(); // Crear un string builder
                for (int i = 0; i < bytes.Length; i++) // Recorrer los bytes para convertirlos a string
                {
                    builder.Append(bytes[i].ToString("x2")); // Convertir los bytes a string
                }
                return builder.ToString(); // Retornar el string encriptado
            }
        }
    }
}
