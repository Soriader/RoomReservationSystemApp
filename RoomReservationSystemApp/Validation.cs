namespace RoomReservationSystemApp;

public class Validation
{
    public static int InputValidation(string userAnswer)
    {
        while(!int.TryParse(userAnswer, out int number))
        {
            Console.WriteLine("Please enter a correct number");
            userAnswer = Console.ReadLine();
        }
        
        return int.Parse(userAnswer);
    }
}