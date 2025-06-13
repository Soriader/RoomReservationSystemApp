namespace RoomReservationSystemApp.TypeOfRoom;

public class StandardRoom : IRoom
{
    public int Number { get; }
    public string Type { get; } = "Standard";
    public decimal BasePrice { get; }
    public bool IsAvailable { get; set; } = true;
    

    public StandardRoom(int number) 
    {
        Number = number;
    }
    
}