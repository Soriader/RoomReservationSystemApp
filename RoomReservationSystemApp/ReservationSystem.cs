namespace RoomReservationSystemApp;

public class ReservationSystem
{
    public void BookRoom(IRoom room, int stayDays) 
    {
        if (!room.IsAvailable)
        {
            Console.WriteLine("Room is not available!");
            return;
        }

        decimal totalPrice = room.CalculatePrice(stayDays);
        Console.WriteLine($"Reservation: Room number: {room.Number} Type: ({room.Type})");
        Console.WriteLine($"Cost: {totalPrice} zł for {stayDays} days");
        room.IsAvailable = false;
    }
}