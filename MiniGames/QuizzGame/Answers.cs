using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGame
{
    internal class Answers
    {
        int option;
        public int _result { get; set; } 
        public void AnswersOne()
        {
            Console.WriteLine("1. Charles Buddy Holly");
            Console.WriteLine("2. Charles Hardin Holley C");
            Console.WriteLine("3. Buddie Charles Holly");
            Console.WriteLine("4. Bobby Charles Holley");
            option = Convert.ToInt32(Console.ReadLine());
            if (option == 2)
            {
                _result++;
            }
        }

        public void AnswersTwo()
        {
            Console.WriteLine("1. Clifford Richard Webb");
            Console.WriteLine("2. Harry Rodger Webb C");
            Console.WriteLine("3. Richard Harold Clifton");
            Console.WriteLine("4. Harold Richard Webb");
            option = Convert.ToInt32(Console.ReadLine());
            if (option == 2)
            {
                _result++;
            }
        }

        public void AnswersThree()
        {
            Console.WriteLine("1. William Albert Iddolson");
            Console.WriteLine("2. William Michael idol");
            Console.WriteLine("3. Michael William Iddol");
            Console.WriteLine("4. William Michael Albert Broad C");
            option = Convert.ToInt32(Console.ReadLine());
            if (option == 4)
            {
                _result++;
            }
        }
    }
}
