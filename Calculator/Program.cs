using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the expression you want to evaluate.");
            var exp = Console.ReadLine();

            try
            {
                var r = new TerminalCalculator().Eval(exp);
                Console.WriteLine($"Result: {r}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
