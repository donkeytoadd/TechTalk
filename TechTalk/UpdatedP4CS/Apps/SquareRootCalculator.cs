namespace XLN_TechTalk.UpdatedP4CS.Apps
{
    using System;
    using p4cs;

    public class SquareRootCalculator : IApp
    {
        public void Run()
        {
            Console.WriteLine("\nSquare Root Calculator\n----------------------");

            double number = this.GetValidInput("Enter a positive number: ", x => x > 0);
            int decimals = (int)this.GetValidInput("How many decimal places? (0-10): ", x => x >= 0 && x <= 10);

            double precision = Math.Pow(10, -decimals);
            double lower = 0, upper = number;
            double mid = 0;

            while (upper - lower > precision)
            {
                mid = (upper + lower) / 2;
                if (mid * mid > number)
                    upper = mid;
                else
                    lower = mid;
            }

            Console.WriteLine($"The square root of {number} is approximately {mid}");
        }

        public double GetValidInput(string prompt, Func<double, bool> validator)
        {
            double input;
            do
            {
                Console.Write(prompt);
                bool valid = double.TryParse(Console.ReadLine(), out input) && validator(input);
                if (valid) return input;
                Console.WriteLine("Invalid input. Please try again.");
            } while (true);
        }
    }
}
