using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Seccion9TareaParte1y2
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Primer programa");
            string palabra;
            string palabraInvertida = "";

            Console.WriteLine("Introduce una palabra. Verificaremos si es un palíndromo: ");
            palabra = Console.ReadLine();

            foreach (char letra in palabra)
            {
                palabraInvertida = letra + palabraInvertida; 
            }

            if (palabra.Equals(palabraInvertida, StringComparison.OrdinalIgnoreCase)) 
            {
                Console.WriteLine("La palabra sí es un palíndromo");
            }
            else
            {
                Console.WriteLine("La palabra no es un palíndromo");
            }

            Console.WriteLine("Segundo programa");
            string fechaNaci;
            DateTime fechaNaciConvertida;

            Console.WriteLine("\nDigite su fecha de nacimiento, en día, mes y año (por ejemplo, 22/09/1990 ), y te diré en qué día de la semana naciste: ");
            fechaNaci = Console.ReadLine();

            fechaNaciConvertida = DateTime.Parse(fechaNaci);

            Console.WriteLine($"Naciste un día {fechaNaciConvertida.ToString("dddd")}"); 
        }
    }
}
