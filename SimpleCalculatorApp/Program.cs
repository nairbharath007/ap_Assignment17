using MathOperationsLibrary;

namespace SimpleCalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.WriteLine("Simple Calculator");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.Write("Enter your choice (1/2): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter first number: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int num2 = int.Parse(Console.ReadLine());

                int result = calculator.Add(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
            else if (choice == "2")
            {
                Console.Write("Enter first number: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int num2 = int.Parse(Console.ReadLine());

                int result = calculator.Subtract(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose 1 or 2.");
            }
        }
    }
}