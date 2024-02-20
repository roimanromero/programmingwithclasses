using System;
using System.Collections.Generic;
using System.Linq;

class Goal
{
    private string name;
    private int points;

    public Goal(string name)
    {
        this.name = name;
        this.points = 0;
    }

    public string Name { get => name; }

    public int Points
    {
        get => points;
        protected set => points = value;
    }

    public virtual void RecordEvent()
    {
        points += 100; // Default points for a simple event
    }

    public virtual string GetGoalStatus()
    {
        return $"[{(IsGoalComplete() ? "X" : " ")}] {name} - Completed {points} times";
    }

    public virtual bool IsGoalComplete()
    {
        return false;
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name) : base(name) { }

    public override void RecordEvent()
    {
        base.RecordEvent();
        // Additional points or logic for specific simple goals
        if (Name.ToLower().Contains("visit a different city"))
            Points += 300; // Bonus points for visiting a different city
        else if (Name.ToLower().Contains("water"))
            Points += 50; // Bonus points for drinking water
        else if (Name.ToLower().Contains("university projects"))
            Points += 200; // Bonus points for finishing university projects
        else if (Name.ToLower().Contains("review and categorize daily expenses"))
            Points += 150; // Bonus points for reviewing and categorizing daily expenses
        else if (Name.ToLower().Contains("connect with a friend or family member"))
            Points += 120; // Bonus points for connecting with a friend or family member
        else if (Name.ToLower().Contains("exercise for 30 minutes daily"))
            Points += 180; // Bonus points for exercising for 30 minutes daily
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name) : base(name) { }

    public override bool IsGoalComplete()
    {
        return false; // Eternal goals are never complete
    }
}

class ChecklistGoal : Goal
{
    private int targetCount;
    private int completedCount;

    public ChecklistGoal(string name, int targetCount) : base(name)
    {
        this.targetCount = targetCount;
        this.completedCount = 0;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        completedCount++;
        if (completedCount == targetCount)
            Points += 500; // Bonus points for completing the checklist goal
    }

    public override string GetGoalStatus()
    {
        return $"[{(IsGoalComplete() ? "X" : " ")}] {Name} - Completed {completedCount}/{targetCount} times";
    }

    public override bool IsGoalComplete()
    {
        return completedCount == targetCount;
    }
}

class EternalQuestProgram
{
    static void Main()
    {
        List<Goal> goals = new List<Goal>();

        // Example goals
        goals.Add(new SimpleGoal("Visit a Different City"));
        goals.Add(new SimpleGoal("Drink 8 Glasses of Water"));
        goals.Add(new SimpleGoal("Finish University Projects"));
        goals.Add(new SimpleGoal("Review and Categorize Daily Expenses"));
        goals.Add(new SimpleGoal("Connect with a Friend or Family Member"));
        goals.Add(new SimpleGoal("Exercise for 30 Minutes Daily"));
        goals.Add(new EternalGoal("Pray"));
        goals.Add(new EternalGoal("Share the Gospel with Someone"));
        goals.Add(new ChecklistGoal("Take a Break 2 Times During the Day", 2));

        // Record events
        foreach (Goal goal in goals)
        {
            goal.RecordEvent();
        }

        // Display goal status
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetGoalStatus());
        }

        // Display total score
        int totalScore = goals.Sum(goal => goal.Points);
        Console.WriteLine($"Total Score: {totalScore}");
    }
}
