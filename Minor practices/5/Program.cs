using System;

namespace Tarea7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombreAr, apellidosAr, direccionAr, rfcAr;
            double saldoAr = 0;
            int opcion;

            Console.WriteLine("| Banco Promérica |");
            Console.WriteLine();
            Console.WriteLine("Digite su nombre: ");
            nombreAr = Console.ReadLine() ?? "";
            Console.WriteLine("Digite sus apellidos: ");
            apellidosAr = Console.ReadLine() ?? "";
            Console.WriteLine("Digite su dirección de domicilio: ");
            direccionAr = Console.ReadLine() ?? "";
            Console.WriteLine("Digite su código de RFC: ");
            rfcAr = Console.ReadLine() ?? "";

            CuentaBancaria cliente = new CuentaBancaria(nombreAr, apellidosAr, direccionAr, rfcAr, saldoAr);

            opcion = cliente.Opciones();

            do
            {
                switch (opcion)
                {
                    case 1:
                        double montoAr;
                        Console.WriteLine("Digite el monto a depositar");
                        montoAr = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Depósito realizado con éxito. Su nuevo saldo es {cliente.Deposito(montoAr)}");
                        break;

                    case 2:
                        double retiroAr;
                        Console.WriteLine("Digite el monto a retirar: ");
                        retiroAr = Convert.ToDouble(Console.ReadLine());
                        cliente.Retiro(retiroAr);
                        break;

                    case 3:
                        cliente.ConsultaSaldo();
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine(cliente.ToString());
                        break;

                    default:
                        Console.WriteLine("Número incorrecto. Intente de nuevo ingresando únicamente un número entre 1 a 5.");
                        break;
                }

                opcion = cliente.Opciones();

            } while (opcion != 5);
        }
    }
    class CuentaBancaria
    {
        string nombre, apellidos, direccion, rfc;
        double saldo;
        public CuentaBancaria(string nombrePa, string apellidosPa, string direccionPa, string rfcPa, double saldoPa)
        {
            this.nombre = nombrePa;
            this.apellidos = apellidosPa;
            this.direccion = direccionPa;
            this.rfc = rfcPa;
            this.saldo = saldoPa;
        }
        public double Deposito(double montoPa)
        {
            saldo += montoPa;
            return saldo;
        }
        public double Retiro(double montoPa)
        {
            double retiro;
            retiro = montoPa;

            if ((retiro <= saldo) && (saldo > 0))
            {
                saldo -= retiro;
                Console.WriteLine($"Transacción realizada exitosamente. Su saldo actual es: {saldo}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente");
                Console.WriteLine($"Transacción no realizada. Su saldo actual es: {saldo}");
            }
            return saldo;
        }
        public void ConsultaSaldo()
        {
            Console.WriteLine("Su saldo actual es: {0}", saldo);
        }
        public override string ToString()
        {
            string mensaje;
            mensaje = "Nombre: " + nombre + " " + "\nApellidos: " + apellidos + " " + "\nDirección: " + direccion + " " + "\nRegistro Federal de Contribuyentes: " + rfc + " " + "\nSaldo actual: " + saldo;
            return mensaje;
        }
        public int Opciones()
        {
            int opcionElegida;
            Console.WriteLine();
            Console.WriteLine("Elija la opción que desea: ");
            Console.WriteLine("1. Depósito.");
            Console.WriteLine("2. Retiro.");
            Console.WriteLine("3. Consultar saldo.");
            Console.WriteLine("4. Mostrar información de la cuenta.");
            Console.WriteLine("5. Salir.");
            opcionElegida = Convert.ToInt32(Console.ReadLine());

            return opcionElegida;
        }
    }
}
