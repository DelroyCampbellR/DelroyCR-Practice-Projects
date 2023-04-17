using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seccion9TareaParte3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string nombreUsuario, opcion, contraseñaFinal;

           
            (bool contraseñaValida, string mensajeError) verificarContraseña;

            Console.WriteLine("\t\tRegistro\n\n");

            Console.Write("Ingrese un nombre de usuario: ");
            nombreUsuario = Console.ReadLine();

            Console.Write("¿Desea que le generemos una contraseña segura? (si/no): ");
            opcion = Console.ReadLine();

            opcion = opcion.ToLower(); 


            switch (opcion)
            {
                case "si":
                   
                    Contraseña contraseñaClase = new Contraseña();

                   
                    contraseñaFinal = contraseñaClase.GenerarContraseña();

                    Console.WriteLine($"Esta es la contraseña que generamos para ti, guárdala en un lugar seguro antes de continuar: \n\n{contraseñaFinal}");
                    Console.Write("\nPresiona cualquier tecla para terminar tu registro ");
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine($"\nTus datos de acceso son los siguientes: \n\tUsuario: {nombreUsuario}\n\tContraseña: {contraseñaFinal}");

                    break;

                case "no":
                    Console.WriteLine("\nIngrese una contraseña segura. La contraseña cumplir con los siguientes requisitos: \n\nDebe contener entre 8-20 carácteres en total. \nDebe contener al menos un número. \nDebe contener al menos una mayúscula. \nDebe contener al menos una minúscula. \nDebe contener al menos uno de los siguientes carácteres especiales válidos: $%#&!?\n");
                    contraseñaFinal = Console.ReadLine();

                    Contraseña contraseñaClase2 = new Contraseña();

                    verificarContraseña = contraseñaClase2.ComprobarContraseña(contraseñaFinal);

                    if (verificarContraseña.contraseñaValida)
                    {
                        Console.Write("\nPresiona cualquier tecla para terminar tu registro ");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine($"\nTus datos de acceso son los siguientes: \n\tUsuario: {nombreUsuario}\n\tContraseña: {contraseñaFinal}");
                    }

                    else
                    {

                        Console.WriteLine(verificarContraseña.mensajeError + " Ingresa una contraseña válida.");
                    }
                    break;
            }
        }
    }
    

    class Contraseña
    {
        
        string numeros = "0123456789";
        string letrasMin = "abcdefghijklmnopqrstuvwxyz";
        string letrasMay = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string caracterEspecial = "$%#&!?";

        int numContiene = 0, minContiene = 0, mayContiene = 0, espContiene = 0;

        public string GenerarContraseña()
        {
            
            Random random = new Random();

            
            int longitudContraseña = random.Next(8, 21); 

            
            double numTener = longitudContraseña * .15; 
            double minTener = longitudContraseña * .35;
            double mayTener = longitudContraseña * .35;
            double espTener = longitudContraseña * .15;

            char caracterEscogido;

            StringBuilder contraseñaGenerada = new StringBuilder();

            while (contraseñaGenerada.Length < longitudContraseña) 
            {
                switch (random.Next(0, 4))
                {
                    case 0: 
                        if (numContiene < numTener)
                        {
                            
                            caracterEscogido = numeros[random.Next(numeros.Length)];
                            contraseñaGenerada.Append(caracterEscogido);

                            numContiene++; 
                        }
                        break;

                    case 1: 
                        if (minContiene < minTener)
                        {
                            caracterEscogido = letrasMin[random.Next(letrasMin.Length)];
                            contraseñaGenerada.Append(caracterEscogido);

                            minContiene++;
                        }
                        break;

                    case 2: 

                        if (mayContiene < mayTener)
                        {
                            caracterEscogido = letrasMay[random.Next(letrasMay.Length)];
                            contraseñaGenerada.Append(caracterEscogido);

                            mayContiene++;
                        }
                        break;

                    case 3: 

                        if (espContiene < espTener)
                        {
                            caracterEscogido = caracterEspecial[random.Next(caracterEspecial.Length)];
                            contraseñaGenerada.Append(caracterEscogido);
                            espContiene++;
                        }
                        break;
                }
            }

            return contraseñaGenerada.ToString();
        }


        public (bool, string) ComprobarContraseña(string contraseñaPa) 
        {
            bool contraseñaValida = false;

            bool hayNumero = false, hayMinuscula = false, hayMayuscula = false, hayEspecial = false;

            string mensajeError = "";

            if (contraseñaPa.Length >= 8 && contraseñaPa.Length <= 20)
            {
                foreach (char elemento in numeros) 
                {
                    
                    if (contraseñaPa.IndexOf(elemento) >= 0) 
                    {
                        hayNumero = true; 
                        break; 
                    }
                    else
                    {
                        hayNumero = false;
                        mensajeError = "La contraseña debe contener al menos un número.";
                        
                    }
                }

                if (hayNumero) 
                {
                    
                    foreach (char elemento in letrasMin)
                    {
                        if (contraseñaPa.IndexOf(elemento) >= 0)
                        {
                            hayMinuscula = true;
                            break;
                        }
                        else
                        {
                            hayMinuscula = false;
                            mensajeError = "La contraseña debe contener al menos una letra minúscula.";
                        }
                    }

                    if (hayMinuscula)
                    {
                        foreach (char elemento in letrasMay)
                        {
                            if (contraseñaPa.IndexOf(elemento) >= 0)
                            {
                                hayMayuscula = true;
                                break;
                            }
                            else
                            {
                                hayMayuscula = false;
                                mensajeError = "La contraseña debe contener al menos una letra mayúscula.";
                            }
                        }

                        if (hayMayuscula)
                        {
                            foreach (char elemento in caracterEspecial)
                            {
                                if (contraseñaPa.IndexOf(elemento) >= 0)
                                {
                                    hayEspecial = true;
                                    break;
                                }
                                else
                                {
                                    hayEspecial = false;
                                    mensajeError = "La contraseña debe contener al menos un carácter especial (%#&!?).";
                                }
                            }
                        }
                    }
                }
                
                if (hayNumero && hayMinuscula && hayMayuscula && hayEspecial) 
                {
                    
                    contraseñaValida = true;
                }
                else
                {
                   
                    contraseñaValida = false;
                }
            }
            else
            {
                
                mensajeError = "La contraseña debe contener entre 8-20 caracteres.";
                contraseñaValida = false; 
            }

           
            return (contraseñaValida, mensajeError);
        }
    }
}
