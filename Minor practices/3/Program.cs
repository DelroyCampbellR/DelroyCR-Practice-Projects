using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double gradosAr, radianes, resultadoCir, resultadoCuad, resultadoTri;
            Console.WriteLine("Ingresa los grados a convertir: ");
            gradosAr = Convert.ToDouble(Console.ReadLine());

            radianes = GradosRadianes(gradosAr);

            Console.WriteLine("{0}° = {1} radianes", gradosAr, radianes);

            Console.WriteLine();

            byte figura;
            Console.WriteLine("Escribe el número de la figura la cuál deseas calcular el área:");
            Console.WriteLine("1 = Círculo");
            Console.WriteLine("2 = Cuadrado");
            Console.WriteLine("3 = Triángulo");
            figura = Convert.ToByte(Console.ReadLine());

            switch (figura)
            {
                case 1:
                    resultadoCir = Circulo();
                    Console.WriteLine("El área es: {0}", resultadoCir);
                    break;
                case 2:
                    resultadoCuad = Cuadrado();
                    Console.WriteLine("El área es: {0}", resultadoCuad);
                    break;
                case 3:
                    resultadoTri = Triangulo();
                    Console.WriteLine("El área es: {0}", resultadoTri);
                    break;
                default:
                    Console.WriteLine("Número incorrecto. Programa finalizado. Intente de nuevo.");
                    break;
            }
        }

        static double Circulo()
        {
            double radio, resultado;
            Console.WriteLine("Digite el radio: ");
            radio = Convert.ToSingle(Console.ReadLine());

            resultado = radio * radio * Math.PI;

            return resultado;
        }

        static double Cuadrado()
        {
            double lado, resultado;
            Console.WriteLine("Digite la medida de un lado: ");
            lado = Convert.ToSingle(Console.ReadLine());

            resultado = lado * lado;

            return resultado;
        }
        static double Triangulo()
        {
            double baseT, altura, resultado;
            Console.WriteLine("Digite la medida de la base: ");
            baseT = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Digite la medida de la altura: ");
            altura = Convert.ToSingle(Console.ReadLine());

            resultado = (baseT * altura) / 2;

            return resultado;
        }

        static double GradosRadianes(double gradosPa)
        {
            double radianes;

            radianes = (gradosPa * Math.PI) / 180;
            return radianes;
        }
    }
}
