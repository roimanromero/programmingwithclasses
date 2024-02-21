using System;
using System.Collections.Generic;

class Activity
{
    public DateTime Date { get; set; }
    public int LengthInMinutes { get; set; }

    public Activity(DateTime date, int lengthInMinutes)
    {
        Date = date;
        LengthInMinutes = lengthInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0; // To be overridden in derived classes
    }

    public virtual double GetSpeed()
    {
        return 0; // To be overridden in derived classes
    }

    public virtual double GetPace()
    {
        return 0; // To be overridden in derived classes
    }

    public string GetSummary()
    {
        return $"{Date.ToShortDateString()} - {GetType().Name} ({LengthInMinutes} min)";
    }
}

class Running : Activity
{
    public double Distance { get; set; }

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (LengthInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return LengthInMinutes / Distance;
    }
}

class Cycling : Activity
{
    public double Speed { get; set; }

    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        Speed = speed;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60.0 / Speed;
    }
}

class Swimming : Activity
{
    public int Laps { get; set; }
    private const double LapDistanceInMeters = 50;

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * LapDistanceInMeters / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (LengthInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance();
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 30, 20.0),
            new Swimming(new DateTime(2022, 11, 3), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine($"Distance: {activity.GetDistance()} km");
            Console.WriteLine($"Speed: {activity.GetSpeed()} km/h");
            Console.WriteLine($"Pace: {activity.GetPace()} min/km\n");
        }
    }
}