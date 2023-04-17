using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cálculo de la potencia de un número:");
            double resultado = 1;
            double bas;
            double expo;
            double resultado_negativo;

            Console.WriteLine("Digite el número base");
            bas = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite el exponente");
            expo = Convert.ToInt32(Console.ReadLine());

            if (expo < 0) 
            {
                expo *= -1;

                for (int i = 1; i <= expo; i++) 
                {
                    resultado *= bas;
                }

                resultado_negativo = (1 / resultado); 
                Console.WriteLine("{0}^{1} = {2}", bas, expo, resultado_negativo);
            }

            else
            {
                for (int i = 1; i <= expo; i++)
                {
                    resultado *= bas; 
                }
                Console.WriteLine("{0}^{1} = {2}", bas, expo, resultado);
            }

            Console.WriteLine("Cálculo de números primos entre 1 y 100:");

            int numero, divisor, numDivisores = 0;

            for (numero = 2; numero <= 100; numero++)
            {
                for (divisor = 1; divisor <= numero; divisor++)
                {
                    if (numero % divisor == 0)
                    {
                        numDivisores += 1; 
                    }
                }

                if (numDivisores <= 2)
                {
                    Console.WriteLine(numero);
                }

                numDivisores = 0;
            }

            Console.ReadKey();
        }
    }
}
