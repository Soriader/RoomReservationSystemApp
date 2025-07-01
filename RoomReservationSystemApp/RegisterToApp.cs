namespace RoomReservationSystemApp;

public class RegisterToApp
{
    private readonly Validation _validation; 
    private readonly ClientRepository _repository;
    public void Login()
    {
        Console.WriteLine("You are a 1.customer or 2.administrator");
        var answer = Console.ReadLine();
        
        while(_validation.IsUserNumberAnswerValid(answer, 2))
        {
            answer = Console.ReadLine();
        }

        switch (answer)
        {
            case "1":
            {
                CreateUser();
                break;
            }
            case "2":
            {
                break;
            }
        }
    }

    private ClientDB CreateUser() //to be completed
    {
        var name = UserName();
        var surname = "";
        var email = "";


        var newUser = new User($"{name} {surname}", email);
        
        /*_repository.Insert(newUser);  
        _repository.Save(); */

        return null; 
    }

    private string UserName()
    {
        Console.WriteLine("Please enter your first name: ");
        var userAnswer = Console.ReadLine();

        while (_validation.IsCorrectName(userAnswer))
        {
            Console.WriteLine("Please enter correct your first name: ");
            userAnswer = Console.ReadLine();
        }
        
        return userAnswer;
    }
}