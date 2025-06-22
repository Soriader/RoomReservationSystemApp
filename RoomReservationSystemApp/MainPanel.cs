namespace RoomReservationSystemApp;

public class MainPanel
{
    private readonly Validation _validation;
    private readonly RoomService _roomService;
    private readonly ReservationService _reservationService;

    public void Welcome()
    {
        Console.WriteLine("Welcome in our reservation system! What you want to do?" +
                          "\n1. Room reservation" +
                          "\n2. Check the available rooms" );
        
        var answer = Console.ReadLine();

        while (!_validation.IsUserNumberAnswerValid(answer, 2))
        {
            Console.WriteLine("Please enter a valid number");
            answer = Console.ReadLine();
        }

        
    }

}