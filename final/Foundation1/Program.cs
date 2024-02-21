using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length (seconds): {LengthInSeconds}");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        foreach (var comment in Comments)
        {
            Console.WriteLine($"Comment by {comment.CommenterName}: {comment.CommentText}");
        }

        Console.WriteLine();
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>
        {
            new Video("Video 1", "Author 1", 120),
            new Video("Video 2", "Author 2", 180),
            new Video("Video 3", "Author 3", 150),
        };

        videos[0].AddComment(new Comment("User1", "Great video!"));
        videos[0].AddComment(new Comment("User2", "Interesting content."));
        videos[1].AddComment(new Comment("User3", "I learned a lot."));
        videos[2].AddComment(new Comment("User4", "Keep it up!"));

        foreach (var video in videos)
        {
            video.DisplayDetails();
        }
    }
}
