using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGame
{
    public class GameStart
    {
        public string? _name { get; set; } 

        public void Start()
        {
            Console.WriteLine("Welcome. Type your name!");
            _name = Console.ReadLine() ?? "DEFAULT";

            Console.WriteLine("Choose the right answers to the next questions to win!");
        }
    }
}
