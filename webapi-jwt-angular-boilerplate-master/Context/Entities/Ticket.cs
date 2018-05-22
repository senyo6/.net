using Context;
using System;

public class Ticket : Entity
{
    public string Name { get; set; }
    public float Price { get; set; }
    public int EntryCount { get; set; }
    public int ValidityDayCount { get; set; }
    public string Description { get; set; }
}
