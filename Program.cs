using System;

internal static class Program {
    private static void Main(string[] args) {
        Console.Clear();
        Console.Write("Welcome to my calculator! Type the expression you'd like to calculate. ");
        string input = (string) Console.ReadLine();
        double answer = Calculator.Calculate(input);
        Console.WriteLine($"\nThe answer is: {answer}");
    }
}