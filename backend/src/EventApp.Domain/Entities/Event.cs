using System;
using EventApp.Domain.Enums;

namespace EventApp.Domain.Entities;

public class Event
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public float TicketPrice { get; set; }
    public long MaxCapacity { get; set; }
    public string LocationId { get; set; } = string.Empty;
    public IEnumerable<string> LunchZones { get; set; } = new HashSet<string>();
    public EventState EventState { get; set; }
    public IEnumerable<string> Activities { get; set; } = new HashSet<string>();

    public Event()
    {
        EventState = EventState.Wait;
    }
}