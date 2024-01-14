using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userInputName = PromptUserName();
        int userInputNumber = PromptUserNumber();

        int squaredUserNumber = SquareNumber(userInputNumber);

        DisplayResult(userInputName, squaredUserNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());

        return userNumber;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"Brother/Sister {name}, the square of your number is {square}");
    }
}