using System;
using System.Text;

namespace Ejercicio_Squeaky_Clean
{
    public static class Identifier
    {
        public static string Clean(string identifier)
        {
            var sb = new StringBuilder();
            bool capitalizeNext = false;

            foreach (char c in identifier)
            {
                if (c == ' ')
                {
                    sb.Append('_');
                }
                else if (char.IsControl(c))
                {
                    sb.Append("CTRL");
                }
                else if (c == '-')
                {
                    capitalizeNext = true;
                }
                else if (c >= 'α' && c <= 'ω')
                {
                    continue; // Omitir letras griegas minúsculas
                }
                else if (char.IsLetter(c))
                {
                    if (capitalizeNext)
                    {
                        sb.Append(char.ToUpper(c));
                        capitalizeNext = false;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string resultado = Identifier.Clean("à-ḃç");
            Console.WriteLine(resultado);
        }
    }
}

    

