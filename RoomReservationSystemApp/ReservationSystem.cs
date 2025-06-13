using System.Text;
using RoomReservationSystemApp.TypeOfRoom;

namespace RoomReservationSystemApp;

public class ReservationSystem
{
    readonly IRoom _room;
    readonly RoomReservationRepository _repository;
    readonly ReservationDbContext _context;
    readonly Validation _validation;
    public void BookRoom(IRoom room, int stayDays) 
    {
        Console.WriteLine("That is all room what we have:");
        AllRooms();
        room = ChooseRoom();
        
        if (!room.IsAvailable)
        {
            Console.WriteLine("Room is not available!");
            return;
        }

        decimal totalPrice = CalculatePrice(stayDays, room.BasePrice);
        Console.WriteLine($"Reservation: Room number: {room.Number} Type: ({room.Type})");
        Console.WriteLine($"Cost: {totalPrice} $ for {stayDays} days");
        room.IsAvailable = false;
    }

    public decimal CalculatePrice(int stayDays, decimal basePrice)
    {
        return basePrice * stayDays;
    }

    public IRoom ChooseRoom()
    {
        Console.WriteLine("Choose a room:\n1. Standard\n2. Family\n3. VIP");
        var roomType  = Console.ReadLine();

        while (!_validation.CorrectNumberAnser(roomType , 3))
        {
            roomType  = Console.ReadLine();
        };

        switch (roomType)
        {
            case "1":
            {
                roomType  = "StandardRoom";
                break;
            }
            case "2":
            {
                roomType  = "FamilyRoom";
                break;
            }
            case "3":
            {
                roomType  = "VIPRoom";
                break;
            }
        }

        ShowRoomsByType(roomType);
        
        Console.WriteLine("Enter room number:");
        var answer = Console.ReadLine();
        int number = _validation.InputValidation(answer);
        
        var dbRoom = _context.Rooms
            .FirstOrDefault(r => r.Type == roomType && r.Number == number);

        while (dbRoom == null || !dbRoom.IsAvailable)
        {
            Console.WriteLine("Room is either not found or not available. Try again:");
            answer = Console.ReadLine();
            number = _validation.InputValidation(answer);

            dbRoom = _context.Rooms
                .FirstOrDefault(r => r.Type == roomType && r.Number == number);
        }

        IRoom selectedRoom = roomType switch
        {
            "Standard" => new StandardRoom(number) { IsAvailable = dbRoom.IsAvailable },
            "Family" => new FamilyRoom(number) { IsAvailable = dbRoom.IsAvailable },
            "VIP" => new VIPRoom(number) { IsAvailable = dbRoom.IsAvailable },
            _ => throw new Exception("Unknown room type")
        };

        return selectedRoom;
        
    }

    public string AllRooms()
    {
        var rooms = _repository.GetAll();
    
        var builder = new StringBuilder();

        foreach (var room in rooms)
        {
            builder.AppendLine(
                $"Room {room.Number} | Type: {room.Type} | Available: {(room.IsAvailable ? "Yes" : "No")}");
        }

        _repository.Save();
        return builder.ToString();
    }

    public void ShowRoomsByType(string type)
    {
        var room = _repository.GetByType(type);

        if (room == null)
        {
            Console.WriteLine($"No rooms found for type: {type}");
            return;
        }

        Console.WriteLine($"Room details for type '{type}':");
        Console.WriteLine($"  Room {room.Number} | Type: {room.Type} | Available: {(room.IsAvailable ? "Yes" : "No")}");
    }
    
}