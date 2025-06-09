namespace RoomReservationSystemApp.TypeOfRoom;

public class StandardRoom : IRoom
{
    public int Number { get; }
    public string Type { get; } = "Standard";
    public decimal BasePrice { get; } = 200m;
    public bool IsAvailable { get; set; } = true;

    private const decimal VipFee = 100m; 


    public StandardRoom(int number) 
    {
        Number = number;
    }
    
    public decimal CalculatePrice(int stayDays)
    {
        return BasePrice * stayDays;
        
    }
    
}