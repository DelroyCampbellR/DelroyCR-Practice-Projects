using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGame
{
    internal class Results
    {
        private GameStart start;
        private Answers choices;
        private List<int> scoreHistory = new List<int>();
        private List<string> nameHistory = new List<string>();

        public Results (GameStart start, Answers choices)
        {
            this.start = start ?? new GameStart();
            this.choices = choices ?? new Answers();
        }

        public void FinalResult()
        {
            Console.WriteLine();
            Console.WriteLine("[Final score]");
            Console.WriteLine();
            Console.WriteLine($"User: {start._name ?? "Unknown"}");
            Console.WriteLine($"You've guessed a total of {choices._result}/3 right answers.");
            Console.WriteLine();
            scoreHistory.Add(choices._result);
            nameHistory.Add(start._name ?? "Unknown");

            
            for (int i = 0; i < scoreHistory.Count && i <nameHistory.Count; i++)
            {
                Console.WriteLine($"{nameHistory[i]}: {scoreHistory[i]}");
            }

        }
    }
}
