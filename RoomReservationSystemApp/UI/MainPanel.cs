namespace RoomReservationSystemApp;

public class MainPanel
{
    private readonly Validation _validation;
    private readonly RoomService _roomService;
    private readonly ReservationService _reservationService;

    public void Welcome()
    {
        Console.WriteLine("\n1. Room reservation");
        
        var answer = Console.ReadLine();

        while (!_validation.IsUserNumberAnswerValid(answer, 2))
        {
            Console.WriteLine("Please enter a valid number");
            answer = Console.ReadLine();
        }

        switch (answer)
        {
            case "1":
            {
                _reservationService.BookARoom();
                break;
            }

        }
        
    }

}