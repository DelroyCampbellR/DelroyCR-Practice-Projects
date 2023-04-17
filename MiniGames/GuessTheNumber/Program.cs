
using System.Diagnostics.Metrics;

Console.WriteLine("[Guess the number]");

int num, rnd, attempts = 0;
string bestScore = "No Data";
string option;
Random random = new Random();
rnd = random.Next(1, 11);

do
{
    Console.WriteLine($"Highest score: {bestScore}");
    Console.WriteLine();
    Console.WriteLine("Guess a number between 1 and 10");
    num = Convert.ToInt32(Console.ReadLine());

    if (rnd < num)
    {
        Console.WriteLine("You failed. The number to guess is lower than the one you selected. Try again. ");
        attempts++;
    }

    else if (rnd > num)
    {
        Console.WriteLine("You failed. The number to guess is higher than the one you selected. Try again. ");
        attempts++;
    }

    else
    {
        Console.WriteLine("You won!");
        attempts++;
        Console.WriteLine($"Your attempts {attempts}");

        if (bestScore == "No Data" || attempts < Convert.ToInt32(bestScore))
        {
            bestScore = Convert.ToString(attempts);
        }

        rnd = random.Next(1, 11);
        attempts = 0;
    }

    Console.WriteLine("Do you want to continue? y/n");
    option = Console.ReadLine()?.ToLower() ?? "";
} while (option != "n");