namespace RoomReservationSystemApp;

public class RoomService : IRoom
{
    public int Number { get; }
    public string Type { get; }       
    public decimal BasePrice { get; }  
    public bool IsAvailable { get; set; }

    public RoomService(int number, string type, decimal basePrice, bool isAvailable)
    {
        Number = number;
        Type = type;
        BasePrice = basePrice;
        IsAvailable = isAvailable;
    }
    
    
}