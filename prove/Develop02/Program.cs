using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        // formatting the entry for display
        return $"{Date.ToShortDateString()}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        // to create a new entry and add it to the journal
        Entry newEntry = new Entry(prompt, response, DateTime.Now);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        // Display all entries in the journal
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        // Save the journal to a file
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                // Write each entry to the file in CSV format (date, prompt, response)
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine("Journal saved to file successfully.");
    }

    public void LoadFromFile(string fileName)
    {
        // Clear existing entries before loading from the file
        entries.Clear();

        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    // Read each line from the file and parse it into components
                    var line = reader.ReadLine();
                    var parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        // Create an entry from the loaded components and add it to the journal
                        DateTime date = DateTime.Parse(parts[0]);
                        string prompt = parts[1];
                        string response = parts[2];

                        Entry loadedEntry = new Entry(prompt, response, date);
                        entries.Add(loadedEntry);
                    }
                }
            }

            Console.WriteLine("Journal loaded from file successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading journal: {e.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a Journal instance
        Journal journal = new Journal();
        string choice;

        do
        {
            // Display menu options to the user
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Prompt user with a random prompt and add the response to the journal
                    Console.WriteLine("Random Prompt: Who was the most interesting person you interacted with today?");
                    Console.Write("Your Response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry("Who was the most interesting person you interacted with today?", response);
                    break;
                case "2":
                    // Display all entries in the journal
                    journal.DisplayEntries();
                    break;
                case "3":
                    // Save the journal to a file
                    Console.Write("Enter the filename to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                case "4":
                    // Load the journal from a file
                    Console.Write("Enter the filename to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                case "5":
                    // to quit the program
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    // and this is to handle invalid choices.
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        } while (choice != "5");
    }
}
