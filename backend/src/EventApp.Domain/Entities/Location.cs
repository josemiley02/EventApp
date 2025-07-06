using System;

namespace EventApp.Domain.Entities;

public class Location
{
    public string Id { get; set; } = string.Empty;
    public string AddressDescription { get; set; } = string.Empty;
    public float X { get; set; }
    public float Y { get; set; }
}