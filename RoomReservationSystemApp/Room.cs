namespace RoomReservationSystemApp;

public class Room : IRoom
{
    private readonly Validation _validation;
    private readonly RoomReservationRepository _repository;

    public int Number { get; set; }
    public string Type { get; set; }
    public decimal BasePrice { get; set; }
    public bool IsAvailable { get; set; }

    public Room(Validation validation, RoomReservationRepository repository)
    {
        _validation = validation;
        _repository = repository;
    }

    public Room(int number, string type, decimal basePrice, bool isAvailable, 
               Validation validation, RoomReservationRepository repository)
        : this(validation, repository)
    {
        Number = number;
        Type = type;
        BasePrice = basePrice;
        IsAvailable = isAvailable;
    }

    public IRoom AddNewRoom()
    {
        int number = AddNumber();  
        string type = AddType();  
        decimal basePrice = AddPrice();  

        var newRoom = new Room(number, type, basePrice, true, _validation, _repository);  

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
            return _validation.InputValidationPrice(roomPrice);
        }
        
        return decimal.Parse(roomPrice);
    }
}