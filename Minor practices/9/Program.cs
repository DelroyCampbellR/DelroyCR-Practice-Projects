using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Seccion11Tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombreArchivo = "";
            string cadena = "";
            string ubicacionArchivo = "";

            Console.Write("Dame la ubicacion del archivo: ");
            ubicacionArchivo = Console.ReadLine();

            Console.Write("Dame el nombre del archivo: ");
            nombreArchivo = Console.ReadLine();

            FileStream fs = new FileStream(ubicacionArchivo + "\\" + nombreArchivo + ".doc", FileMode.Append);

            Console.Write("Dame la cadena que quieras introducir en el archivo: ");
            cadena = Console.ReadLine();

            fs.Write(ASCIIEncoding.ASCII.GetBytes(cadena), 0, cadena.Length);

            fs.Close();

        }
    }
}
