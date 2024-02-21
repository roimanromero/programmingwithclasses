using System;

class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public Address Address { get; set; }

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"{GetType().Name}: {Title} - {Date.ToShortDateString()}";
    }
}

public class Address
{
    private string v1;
    private string v2;
    private string v3;
    private string v4;

    public Address(string v1, string v2, string v3, string v4)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
    }
}

class Lecture : Event
{
    public string SpeakerName { get; set; }
    public int Capacity { get; set; }

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speakerName, int capacity)
        : base(title, description, date, time, address)
    {
        SpeakerName = speakerName;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {SpeakerName}\nCapacity: {Capacity} attendees";
    }
}

class Reception : Event
{
    public string RsvpEmail { get; set; }

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {RsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    public string WeatherStatement { get; set; }

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        WeatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather: {WeatherStatement}";
    }
}

class Program
{
    static void Main()
    {
        Lecture lecture = new Lecture("Tech Talk", "Exciting tech discussion", DateTime.Now, new TimeSpan(14, 0, 0),
            new Address("123 Tech St", "TechCity", "TechState", "USA"), "John Doe", 50);

        Reception reception = new Reception("Networking Event", "Connect and network", DateTime.Now.AddDays(7), new TimeSpan(18, 30, 0),
            new Address("456 Connect St", "CityConnect", "StateConnect", "USA"), "rsvp@example.com");

        OutdoorGathering gathering = new OutdoorGathering("Community Picnic", "Enjoy food and games", DateTime.Now.AddDays(14), new TimeSpan(12, 0, 0),
            new Address("789 Park St", "CityPark", "StatePark", "USA"), "Sunny with a chance of rain");

        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("\n" + reception.GetFullDetails());
        Console.WriteLine("\n" + gathering.GetFullDetails());

        Console.WriteLine("\nShort Descriptions:");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine(gathering.GetShortDescription());
    }
}