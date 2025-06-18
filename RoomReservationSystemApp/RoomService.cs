using System.Text;

namespace RoomReservationSystemApp;

public class RoomService : IRoomService
{
    private readonly Validation _validation;
    private readonly RoomReservationRepository _repository;
    
    public RoomService(Validation validation, RoomReservationRepository repository)
    {
        _validation = validation;
        _repository = repository;
    }
    public IRoom AddNewRoom()
    {
        int number = AddNumber();  
        string type = AddType();  
        decimal basePrice = AddPrice();  

        var newRoom = new Room(number, type, basePrice, true);

        var roomDb = new RoomReservationDB(
            number: newRoom.Number,
            type: newRoom.Type,
            basePrice: newRoom.BasePrice,
            isAvailable: newRoom.IsAvailable
        );

        _repository.Insert(roomDb);  
        _repository.Save(); 

        return newRoom;  
    }

    private int AddNumber()
    {
        Console.WriteLine("Add number of room:");
        var userAnswer = Console.ReadLine();
        return _validation.InputValidation(userAnswer);
    }

    private string AddType()
    {
        Console.WriteLine("Add type of room:\n1. Standard\n2. Family\n3. VIP");
        var roomType = Console.ReadLine();

        while (!_validation.CorrectNumberAnser(roomType, 3))
        {
            roomType = Console.ReadLine();
        }

        return roomType switch
        {
            "1" => "StandardRoom",
            "2" => "FamilyRoom",
            "3" => "VIPRoom",
            _ => "StandardRoom" 
        };
    }

    private decimal AddPrice()
    {
        Console.WriteLine("Add price for room on one night:");
        var roomPrice = Console.ReadLine();
        
        while (!_validation.CorrectNumberAnser(roomPrice, 1000))
        {
            Console.WriteLine("Invalid price, please enter again:");
            roomPrice = Console.ReadLine();
        }
        return decimal.Parse(roomPrice);
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
    
    public decimal CalculatePrice(int stayDays, decimal basePrice)
    {
        return basePrice * stayDays;
    }
}
