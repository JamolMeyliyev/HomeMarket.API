﻿namespace HomeMarket.API.Entities;

public class Home
{
    public Guid Id { get; set; }
    public required List<Room> Rooms { get; set; }
    public long Price { get; set; }
    public float Area { get; set; }
    public EComfort Type { get; set; }
    public float EmptyArea { get; set; }


}
