namespace RoomReservationSystemApp.TypeOfRoom;

public class FamilyRoom : IRoom
{
    public int Number { get; }
    public string Type { get; } = "Familly Room";
    public decimal BasePrice { get; } = 240m;
    public bool IsAvailable { get; set; } = true;
    
    public FamilyRoom(int number) 
    {
        Number = number;
    }
    
    public decimal CalculatePrice(int stayDays)
    {
        return BasePrice * stayDays;
    }

    
}