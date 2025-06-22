using System.Text;

namespace RoomReservationSystemApp;

public class ReservationService
{

    private readonly RoomService _roomService;
    private readonly Validation _validation; 
    private readonly RoomReservationRepository _repository;

    public ReservationService(Validation validation, RoomReservationRepository repository, RoomService roomService)
    {
        _validation = validation;
        _repository = repository;
        _roomService = roomService;
    }

    public void BookARoom()
    {
        try
        {
            Console.WriteLine("Available rooms:");
            var availableRooms = GetAllAvailableRooms();
            
            if (!availableRooms.Any())
            {
                Console.WriteLine("Sorry, no rooms available at the moment.");
                return;
            }

            int roomNumber = _validation.GetValidAvailableRoomNumber(availableRooms);
            var room = availableRooms.First(r => r.Number == roomNumber);
            
            int days = GetBookingDuration(room);
            ConfirmAndCompleteBooking(room, days);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during booking: {ex.Message}");
        }
    }

    private List<RoomReservationDB> GetAllAvailableRooms()
    {
        var rooms = _repository.GetAll().Where(r => r.IsAvailable).ToList();
        foreach (var room in rooms)
        {
            Console.WriteLine($"Room {room.Number} | Type: {room.Type} | Price per day: {room.BasePrice}$");
        }
        return rooms;
    }

    private int GetBookingDuration(RoomReservationDB room)
    {
        Console.WriteLine($"\nHow many days would you like to book room {room.Number}? (max 7 days)");
        while (true)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int days) || days < 1 || days > 7)
            {
                Console.WriteLine("Please enter a number between 1 and 7:");
                continue;
            }
            return days;
        }
    }

    private void ConfirmAndCompleteBooking(RoomReservationDB room, int days)
    {
        Console.WriteLine($"\nSummary:");
        Console.WriteLine($"- Room: {room.Number}");
        Console.WriteLine($"- Type: {room.Type}");
        Console.WriteLine($"- Duration: {days} days");
        Console.WriteLine($"- Total price: {_roomService.CalculatePrice(days, room.BasePrice)}$");
        Console.WriteLine("Confirm booking? (yes/no)");

        if (Console.ReadLine().ToLower() == "yes")
        {
            room.IsAvailable = false;
            _repository.Save();
            Console.WriteLine($"\nRoom {room.Number} booked successfully for {days} days!");
        }
        else
        {
            Console.WriteLine("Booking cancelled.");
        }
    }
     
 }