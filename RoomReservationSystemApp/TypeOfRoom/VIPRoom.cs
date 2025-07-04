﻿namespace RoomReservationSystemApp.TypeOfRoom;

public class VIPRoom : IRoom
{
    public int Number { get; }
    public string Type { get; } = "VIP";
    public decimal BasePrice { get; }
    public bool IsAvailable { get; set; } = true;

    private const decimal VipFee = 100m; 


    public VIPRoom(int number) 
    {
        Number = number;
    }
    
}