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

            Console.WriteLine("[Banco Promérica]");
            Console.WriteLine();
            Console.WriteLine("Digite su nombre: ");
            nombreAr = Console.ReadLine();
            Console.WriteLine("Digite sus apellidos: ");
            apellidosAr = Console.ReadLine();
            Console.WriteLine("Digite su dirección de domicilio: ");
            direccionAr = Console.ReadLine();
            Console.WriteLine("Digite su código de RFC: ");
            rfcAr = Console.ReadLine();

            CuentaBancaria cliente = new CuentaBancaria(nombreAr, apellidosAr, saldoAr, direccionAr, rfcAr);

            Console.WriteLine("Elija la opción que desea: ");
            Console.WriteLine("1. Depósito");
            Console.WriteLine("2. Retiro");
            Console.WriteLine("3. Consultar Saldo");
            Console.WriteLine("4. Mostrar información de la cuenta");
            Console.WriteLine("5. Salir");
            opcion = Convert.ToInt32(Console.ReadLine());

            do
            {
                    switch (opcion)
                    {
                        case 1:
                            double montoAr;
                            Console.WriteLine("Digite el monto a depositar: ");
                            montoAr = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Depósito realizado con éxito. Su nuevo saldo es: {0}", cliente.Deposito(montoAr));

                        cliente.Opciones();
                        opcion = Convert.ToInt32(Console.ReadLine());
                        break;

                        case 2:
                            double retiroAr;
                            Console.WriteLine("Digite el monto a retirar: ");
                            retiroAr = Convert.ToDouble(Console.ReadLine());
                            cliente.Retiro(retiroAr);

                        cliente.Opciones();
                        opcion = Convert.ToInt32(Console.ReadLine());
                        break;

                        case 3:
                            cliente.ConsultaSaldo();

                        cliente.Opciones();
                        opcion = Convert.ToInt32(Console.ReadLine());
                        break;

                        case 4:
                            Console.WriteLine();
                            Console.WriteLine(cliente.ToString());

                        cliente.Opciones();
                        opcion = Convert.ToInt32(Console.ReadLine());
                        break;

                        default:
                            Console.WriteLine("Número incorrecto. Intente de nuevo ingresando únicamente números de 1 a 5.");

                        cliente.Opciones();
                        opcion = Convert.ToInt32(Console.ReadLine());
                        break;
                    }; 
            } while (opcion != 5);
        }
    }
    class CuentaBancaria
    {
        string nombre, apellidos, direccion, rfc;
        double saldo;
        public CuentaBancaria(string nombrePa, string apellidosPa, double saldoPa, string direccionPa, string rfcPa)
        {
            nombre= nombrePa;
            apellidos= apellidosPa;
            direccion= direccionPa;
            rfc = rfcPa;
            saldo = saldoPa;
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
                Console.WriteLine("Transacción realizada. Su saldo actual es: {0}", saldo);
            }
            else
            {
                Console.WriteLine("Saldo insuficiente");
                Console.WriteLine("Transacción no realizada. Su saldo actual es: {0}", saldo);
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
        public void Opciones()
        {
            Console.WriteLine();
            Console.WriteLine("Elija la opción que desea: ");
            Console.WriteLine("1. Depósito");
            Console.WriteLine("2. Retiro");
            Console.WriteLine("3. Consultar Saldo");
            Console.WriteLine("4. Mostrar información de la cuenta");
            Console.WriteLine("5. Salir");
        }
    }
}
