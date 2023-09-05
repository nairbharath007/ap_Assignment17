namespace MyConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLibrary.Class1 myClassInstance = new MyLibrary.Class1();

            // Call the GetMessage method from the class library
            string message = myClassInstance.GetMessage();

            // Display the message in the console
            Console.WriteLine(message);
        }
    }
}