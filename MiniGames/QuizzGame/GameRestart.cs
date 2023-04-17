using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGame
{
    internal class GameRestart
    {
        public string? _playAgain { get; set; }
        private bool _rest { get; set; }

        public bool Restart()
        {
            Console.WriteLine("Do you want to play again? Y/N");
            _playAgain = Console.ReadLine()?.ToLower() ?? "";
            if ( _playAgain == "n")
            {
                Console.WriteLine("Game Over. Thanks for playing!");
                Console.WriteLine();
                _rest = false;
            }
            else
            {
                Console.WriteLine("Great! Let's keep it up!");
                Console.WriteLine();
                _rest = true;
            }

            return GetRest();
        }

        public bool GetRest()
        {
            return _rest;
        }
    }
}
