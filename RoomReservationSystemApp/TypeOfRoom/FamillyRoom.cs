namespace RoomReservationSystemApp.TypeOfRoom;

public class FamillyRoom : IRoom
{
    public int Number { get; }
    public string Type { get; } = "Familly Room";
    public decimal BasePrice { get; } = 2400m;
    public bool IsAvailable { get; set; } = true;
    
    public FamillyRoom(int number) 
    {
        Number = number;
    }
    
    public decimal CalculatePrice(int stayDays)
    {
        return BasePrice * stayDays;
    }

    
}