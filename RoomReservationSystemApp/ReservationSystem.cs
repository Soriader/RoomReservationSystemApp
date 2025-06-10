using RoomReservationSystemApp.TypeOfRoom;

namespace RoomReservationSystemApp;

public class ReservationSystem
{
    readonly IRoom _room;
    public void BookRoom(IRoom room, int stayDays) 
    {
        if (!room.IsAvailable)
        {
            Console.WriteLine("Room is not available!");
            return;
        }

        room = ChooseRoom();

        decimal totalPrice = room.CalculatePrice(stayDays);
        Console.WriteLine($"Reservation: Room number: {room.Number} Type: ({room.Type})");
        Console.WriteLine($"Cost: {totalPrice} $ for {stayDays} days");
        room.IsAvailable = false;
    }


    public IRoom ChooseRoom()
    {
        Console.WriteLine("Choose a room:\n1. Standard\n2. Family\n3. VIP");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter room number:");
        var answer = Console.ReadLine();
        
        int number = Validation.InputValidation(answer);

        return choice switch
        {
            1 => new StandardRoom(number),
            2 => new FamilyRoom(number), 
            3 => new VIPRoom(number),
            _ => throw new ArgumentException("Invalid room type")
        };
    }
    
}