namespace FibonacciSeries;
class Program{
    static void Main(){
        FibonacciCalculator fibonacciCalculator = new();

        Console.WriteLine("Enter the number :");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Fibonacci Calculation Result : ");
        fibonacciCalculator.Generate(number);
    }
}