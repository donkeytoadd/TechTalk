namespace XLN_TechTalk.UpdatedP4CS.Apps
{
    using System;
    using p4cs;

    public class CountingGame : IApp
    {
        public void Run()
        {
            int score = 0;
            const int totalQuestions = 10;

            Console.WriteLine("\nKeep Counting\n-------------");
            Console.WriteLine("Answer 10 arithmetic questions. Let's begin!");

            var rand = new Random();
            int lastAnswer = rand.Next(1, 11);

            for (int i = 1; i <= totalQuestions; i++)
            {
                int num = rand.Next(1, 11);
                bool isAddition = rand.Next(0, 2) == 0;
                int correctAnswer = isAddition ? lastAnswer + num : lastAnswer - num;

                Console.WriteLine($"Question {i}: {lastAnswer} {(isAddition ? "+" : "-")} {num}");
                Console.Write("Your answer: ");

                if (int.TryParse(Console.ReadLine(), out int userAnswer) && userAnswer == correctAnswer)
                {
                    score++;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer was {correctAnswer}.");
                }

                lastAnswer = correctAnswer;
            }

            Console.WriteLine($"\nYou scored {score}/{totalQuestions}.");
            Console.WriteLine(score >= 8 ? "Superb!" : score >= 5 ? "Good Job!" : "Better luck next time!");
        }
    }
}
