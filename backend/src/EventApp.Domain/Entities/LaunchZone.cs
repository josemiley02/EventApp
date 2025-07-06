using System;
using EventApp.Domain.Enums;

namespace EventApp.Domain.Entities;

public class LunchZone
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public IEnumerable<string> Menu = new HashSet<string>();
}