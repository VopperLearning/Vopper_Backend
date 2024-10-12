using System;
using System.Text;
using Auth_Module.Auth_Core.Entitys;

namespace Auth_Module.Auth_Core.Repository
{
    public class Generate_Code : IGenerate_Code
    {
        private static readonly char[] caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private readonly Random random;

        public Generate_Code()
        {
            random = new Random();
        }

        public string GenerateCode(int longitud)
        {
             StringBuilder codigo = new StringBuilder(longitud);

            for (int i = 0; i < longitud; i++)
            {
                char letraAleatoria = caracteres[random.Next(caracteres.Length)];
                codigo.Append(letraAleatoria);
            }

            return codigo.ToString();
        }
    }
}