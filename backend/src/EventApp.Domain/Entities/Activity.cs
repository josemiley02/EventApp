using System;
using EventApp.Domain.Enums;

namespace EventApp.Domain.Entities;

public class Activity
{
    public string Id { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long MaxCapacity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }
    public ActivityState ActivityState { get; set; }
}