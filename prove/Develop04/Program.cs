using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Mindfulness Program");

        while (true)
        {
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an activity (1-4): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.Write("Invalid input. Please enter a number between 1 and 4: ");
            }

            if (choice == 4)
            {
                Console.WriteLine("Exiting program. Goodbye!");
                break;
            }

            MindfulnessActivity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                default:
                    throw new InvalidOperationException("Invalid choice.");
            }

            activity.StartActivity();
        }
    }
}

abstract class MindfulnessActivity
{
    public readonly int duration;

    protected MindfulnessActivity()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer for duration: ");
        }
    }

    protected void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

#pragma warning disable CA1822 // Mark members as static
    protected void PauseWithSpinner(int seconds)
#pragma warning restore CA1822 // Mark members as static
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void StartActivity()
    {
        DisplayMessage($"Preparing for {GetType().Name}...");
        PauseWithSpinner(3);

        PerformActivity();

        DisplayMessage("Great job! You have completed the activity.");
        DisplayMessage($"Activity: {GetType().Name}, Duration: {duration} seconds");
        PauseWithSpinner(3);
    }

    protected abstract void PerformActivity();
}

class BreathingActivity : MindfulnessActivity
{
    protected override void PerformActivity()
    {
        DisplayMessage("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        for (int i = 0; i < duration; i += 2)
        {
            DisplayMessage("Breathe in...");
            PauseWithSpinner(1);

            DisplayMessage("Breathe out...");
            PauseWithSpinner(1);
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        // ... add more questions as needed
    };

    protected override void PerformActivity()
    {
        DisplayMessage("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        string prompt = prompts[new Random().Next(prompts.Length)];
        DisplayMessage(prompt);

        foreach (var question in questions)
        {
            DisplayMessage(question);
            PauseWithSpinner(3);
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override void PerformActivity()
    {
        DisplayMessage("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        string prompt = prompts[new Random().Next(prompts.Length)];
        DisplayMessage(prompt);

        Console.WriteLine("You have {0} seconds to think about the prompt and list items:", duration);
        PauseWithSpinner(3);

        Console.WriteLine("Start listing items...");

        // Allow user to list items, you can add more logic here as needed

        DisplayMessage($"You listed {new Random().Next(5, 15)} items.");
    }
}
