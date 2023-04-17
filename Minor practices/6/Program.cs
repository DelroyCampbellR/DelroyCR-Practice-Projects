using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float monto, sumaMontos = 0;
            byte opcion;
            Stack<float> bancoApp = new Stack<float>();

            do
            {
                Console.Clear();
                Console.WriteLine("1. Ingresar gastos");
                Console.WriteLine("2. Mostrar gastos del mes");
                Console.WriteLine("3. Salir");

                opcion = Convert.ToByte(Console.ReadLine());
                Console.Clear();

                if (opcion == 1)
                {
                    Console.Write("Ingrese un gasto: $ ");
                    monto = Convert.ToSingle(Console.ReadLine()); 
                    bancoApp.Push(monto);
                    Console.WriteLine("Gasto registrado con éxito.");
                    sumaMontos += monto;
                    Console.WriteLine();
                    Console.WriteLine("Presiona una tecla para regresar al menú...");
                    Console.ReadKey();
                }

                else if (opcion == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Lista de gastos registrados en total (comenzando por el último):");
                    int i = 0;
                    foreach (float gasto in bancoApp)
                    {
                        Console.WriteLine("{0}. {1}", i++, gasto);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Todos los gastos suman un total de: {0}", sumaMontos);
                    Console.WriteLine();
                    Console.WriteLine("Presiona una tecla para regresar al menú...");
                    Console.ReadKey();
                  
                }
                else
                {
                    Console.WriteLine("Ha elegido salir del programa."); 
                }
            } while (opcion == 1 || opcion == 2);
        }
    }
}
