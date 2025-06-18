namespace RoomReservationSystemApp;

public class Validation
{
    readonly IRoom _room;
    public bool IsUserNumberAnswerValid(string userAnswer, int maxAnswerNumber)
    {
        var isNumber = int.TryParse(userAnswer, out int answer);
    
        if (!isNumber || answer <= 0 || answer > maxAnswerNumber)
        {
            return false;
        }

        return true;
    }
    
    private string RetrieveUserInput(string userAnswer)
    {
        string userInput;
        do
        {
            Console.WriteLine(userAnswer);
            userInput = Console.ReadLine();
        } while (string.IsNullOrEmpty(userInput));

        return userInput;
    }
    
    public int InputValidation(string userAnswer)
    {
        while(!int.TryParse(userAnswer, out int number))
        {
            Console.WriteLine("Please enter a correct number");
            userAnswer = Console.ReadLine();
        }
        
        return int.Parse(userAnswer);
    }

    public decimal InputValidationPrice(string userAnswer)
    {
        while(!decimal.TryParse(userAnswer, out decimal number))
        {
            Console.WriteLine("Please enter a correct number");
            userAnswer = Console.ReadLine();
        }
        
        return decimal.Parse(userAnswer);
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
    
    private bool IsValidYesNoAnswer(string userAnswer)
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