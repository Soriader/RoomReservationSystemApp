namespace RoomReservationSystemApp;

public class Validation
{
    readonly IRoom _room;
    private readonly RoomReservationRepository _repository;


    public bool IsCorrectName(string userAnswer)
    {
        return !string.IsNullOrEmpty(userAnswer) && userAnswer.All(char.IsLetter) && char.IsUpper(userAnswer[0]);
    }
    
    public bool IsCorrectMailName(string userAnswer)
    {
        if (string.IsNullOrEmpty(userAnswer) || userAnswer.Length < 3 || userAnswer.Length > 30)
        {
            return false;
        }

        if (!char.IsLetter(userAnswer[0]))
        {
            return false;
        }

        foreach (char c in userAnswer)
        {
            if (!(char.IsLetterOrDigit(c) || c == '.' || c == '_' || c == '-'))
            {
                return false;
            }
        }

        for (int i = 0; i < userAnswer.Length - 1; i++)
        {
            if ((userAnswer[i] == '.' || userAnswer[i] == '_' || userAnswer[i] == '-') &&
                (userAnswer[i+1] == '.' || userAnswer[i+1] == '_' || userAnswer[i+1] == '-'))
            {
                return false;
            }
        }

        if (!char.IsLetterOrDigit(userAnswer[^1]))
        {
            return false;
        }

        return true;
    }
    
    public int GetValidAvailableRoomNumber(List<RoomReservationDB> availableRooms)
    {
        Console.WriteLine("\nPlease enter room number:");
        while (true)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int roomNumber))
            {
                Console.WriteLine("Invalid number format. Please try again:");
                continue;
            }

            if (availableRooms.Any(r => r.Number == roomNumber))
                return roomNumber;

            Console.WriteLine("Room not available or doesn't exist. Please choose from available rooms:");
        }
    }
    
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
    
    public bool IsValidYesNoAnswer(string userAnswer)
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
