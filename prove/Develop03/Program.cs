using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }
}

public class Reference
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int VerseStart { get; set; }
    public int VerseEnd { get; set; }

    public Reference(string reference)
    {
        // Parse the scripture reference to extract book, chapter, and verses
        // Example: "John 3:16" or "Proverbs 3:5-6"
        string[] parts = reference.Split(' ');
        Book = parts[0];
        string[] chapterVerse = parts[1].Split(':');
        Chapter = int.Parse(chapterVerse[0]);

        string[] verses = chapterVerse[1].Split('-');
        VerseStart = int.Parse(verses[0]);
        VerseEnd = verses.Length > 1 ? int.Parse(verses[1]) : VerseStart;
    }
}

public class Scripture
{
    private List<Word> words;
    private int hiddenWordCount;

    public Reference Reference { get; set; }

    public Scripture(string reference, string text)
    {
        Reference = new Reference(reference);
        InitializeWords(text);
        hiddenWordCount = 0;
    }

    private void InitializeWords(string text)
    {
        words = text.Split(' ').Select(w => new Word { Text = w, IsHidden = false }).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{Reference.Book} {Reference.Chapter}:{Reference.VerseStart}-{Reference.VerseEnd}");
        foreach (var word in words)
        {
            Console.Write(word.IsHidden ? "____ " : $"{word.Text} ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 4);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            if (!words[index].IsHidden)
            {
                words[index].IsHidden = true;
                hiddenWordCount++;
            }
        }
    }

    public bool AreAllWordsHidden()
    {
        return hiddenWordCount == words.Count;
    }
}

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");

        do
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to end the program.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        } while (!scripture.AreAllWordsHidden());
    }
}
