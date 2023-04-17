using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int opcionUsuario;
        bool hayResultados;
        string textoABuscar;
        Dictionary<string, Componente> componentes =
            new Dictionary<string, Componente>();

        componentes.Add("1111A",
            new Componente("1111A", "Monitor", "LG", "2234S", 99.95f));
        componentes.Add("2222B",
            new Componente("2222B", "Tarjeta gráfica", "NVidia", "GTX 1060", 130.45f));
        componentes.Add("3333C",
            new Componente("3333C", "Monitor", "Benq", "EL287U", 119.65f));
        componentes.Add("4444D",
            new Componente("4444D", "Disco duro", "Samsung", "SSD 512GB", 103.15f));
        componentes.Add("5555E",
            new Componente("5555E", "Disco duro", "Kingston", "SSD 2TB", 319.05f));


        do
        {
            Console.Clear();
            Console.WriteLine("Escoge una opción:");
            Console.WriteLine("1. Buscar por código");
            Console.WriteLine("2. Buscar por categoría");
            Console.WriteLine("0. Salir");

            opcionUsuario = Convert.ToInt32(Console.ReadLine());

            switch (opcionUsuario)
            {
                case 1:

                    Console.WriteLine("Escribe el código del componente:");
                    textoABuscar = Console.ReadLine();
                    if (componentes.ContainsKey(textoABuscar))
                    {
                        Console.WriteLine(componentes[textoABuscar]);
                    }
                    else
                    {
                        Console.WriteLine("Componente no encontrado.");
                    }
                    break;

                case 2:

                    Console.WriteLine("Escribe el nombre de la categoría:");
                    textoABuscar = Console.ReadLine();
                    hayResultados = false;

                    foreach (KeyValuePair<string, Componente> componente
                        in componentes) 
                    {
                        if (componente.Value.Categoria == textoABuscar) 
                        {
                            Console.WriteLine(componente.Value); 
                            hayResultados = true;
                        }
                    }

                    if (!hayResultados)
                    {
                        Console.WriteLine("No se han encontrado resultados.");
                    }

                    break;

                case 0:

                    Console.WriteLine("Fin del programa.");
                    break;

                default:

                    Console.WriteLine("Opción no reconocida.");
                    break;
            }

            Console.WriteLine("Pulsa Intro para continuar...");
            Console.ReadLine();

        } while (opcionUsuario != 0);
    }
}
