namespace RoomReservationSystemApp;

public interface IRoom
{
    int Number { get; }
    string Type { get; }       
    decimal BasePrice { get; }  
    bool IsAvailable { get; set; }

}