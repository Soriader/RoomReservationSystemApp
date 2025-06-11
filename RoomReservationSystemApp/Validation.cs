namespace RoomReservationSystemApp;

public class Validation
{
    readonly IRoom room;
    public static int InputValidation(string userAnswer)
    {
        while(!int.TryParse(userAnswer, out int number))
        {
            Console.WriteLine("Please enter a correct number");
            userAnswer = Console.ReadLine();
        }
        
        return int.Parse(userAnswer);
    }
    
    public bool IsRoomAvailable(IRoom room)
    {
        if (room.IsAvailable)
        {
            Console.WriteLine($"The {room.Type} on number {room.Number} is available" +
                              $"You can rent this room!");
            return true;
        }
        
        Console.WriteLine($"This {room.Type} is not available, you cant't rent it");
        return false;
    }
    
    private bool YesNoValidation(string userAnswer)
    {
        string userInput;
        do
        {
            Console.WriteLine(userAnswer);
            userInput = Console.ReadLine().ToLower();
        } while (userInput != "yes" && userInput != "no");

        return userInput == "yes";
    }
}