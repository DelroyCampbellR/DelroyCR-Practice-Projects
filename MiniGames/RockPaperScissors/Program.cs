Console.WriteLine("Rock Paper Scissors");

var opcion = "";
var continuar = "";
Random random = new Random();
int opcionOponente = 0;

do
{
    Console.WriteLine("Elige Papel, Piedra o Tijera");
    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "Piedra":
            opcionOponente = random.Next(1, 4);

            if ( opcionOponente == 1)
            {
                Console.WriteLine("El oponente ha elegido Papel.");
                Console.WriteLine("Has perdido.");
            }
            else if ( opcionOponente == 2)
            {
                Console.WriteLine("El oponente ha elegido Piedra.");
                Console.WriteLine("Es un empate.");
            }
            else if (opcionOponente == 3)
            {
                Console.WriteLine("El oponente ha elegido Tijera.");
                Console.WriteLine("Has ganado.");
            }
            break;

        case "Papel":
            opcionOponente = random.Next(1, 4);

            if (opcionOponente == 1)
            {
                Console.WriteLine("El oponente ha elegido Papel.");
                Console.WriteLine("Es un empate");
            }
            else if (opcionOponente == 2)
            {
                Console.WriteLine("El oponente ha elegido Piedra.");
                Console.WriteLine("Has ganado.");
            }
            else if (opcionOponente == 3)
            {
                Console.WriteLine("El oponente ha elegido Tijera.");
                Console.WriteLine("Has perdido.");
            }
            break;

        case "Tijera":
            opcionOponente = random.Next(1, 4);

            if (opcionOponente == 1)
            {
                Console.WriteLine("El oponente ha elegido Papel.");
                Console.WriteLine("Has ganado.");
            }
            else if (opcionOponente == 2)
            {
                Console.WriteLine("El oponente ha elegido Piedra.");
                Console.WriteLine("Has perdido.");
            }
            else if (opcionOponente == 3)
            {
                Console.WriteLine("El oponente ha elegido Tijera.");
                Console.WriteLine("Es un empate");
            }
            break;

        default:
            Console.WriteLine("Has escrito una palabra inválida.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("¿Quieres continuar el juego? S/N");
    continuar = Console.ReadLine();

} while (continuar == "S" || continuar =="s");

Console.WriteLine("Fin del juego!");