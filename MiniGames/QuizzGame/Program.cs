using QuizzGame;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Quizz Game");

        GameStart gameStart = new GameStart();
        Questions questions = new Questions();
        Answers answers = new Answers();
        Results results = new Results(gameStart, answers);
        GameRestart gameRestart = new GameRestart();

        do
        {
            gameStart.Start();

            questions.QuestionOne();
            answers.AnswersOne();

            questions.QuestionTwo();
            answers.AnswersTwo();

            questions.QuestionThree();
            answers.AnswersThree();

            results.FinalResult();
            answers._result = 0;

            gameRestart.Restart();

        } while (gameRestart.GetRest() == true);
    }
}