namespace RoomReservationSystemApp;

public class RegisterService
{
    private readonly Validation _validation; 
    private readonly ClientRepository _repository;

    public RegisterService(Validation validation, ClientRepository repository)
    {
        _validation = validation;
        _repository = repository;
    }
    
    public void CreateAccount()
    {
        var user = CreateUser();
        _repository.Insert(user);  
        _repository.Save();
    }

    private ClientDB CreateUser()
    {
        var name = $"{UserName("first")} {UserName("last")}";
        var email = Email();

        return new ClientDB
        {
            Name = name,
            Email = email,
            RoomReservationDBId = null

        };
    }

    private string UserName(string name)
    {
        Console.WriteLine($"Please enter your {name} name: ");
        var userAnswer = Console.ReadLine();

        while (!_validation.IsCorrectName(userAnswer))
        {
            Console.WriteLine($"Please enter correct your {name} name: ");
            userAnswer = Console.ReadLine();
        }
        
        return userAnswer;
    }

    private string Email()
    {
        Console.WriteLine("What domain you have in your email address?" +
                          "\n1. gmail" +
                          "\n2. yahoo" +
                          "\n3. outlook" +
                          "\n4. hotmail" +
                          "\n5. icloud" +
                          "\n6. protonmail" +
                          "\n7. aol" +
                          "\n8. mail" +
                          "\n9. zoho" +
                          "\n10. yandex");
        var userAnswer = Console.ReadLine();
        while (!_validation.IsUserNumberAnswerValid(userAnswer, 10))
        {
            Console.WriteLine("Please enter a valid number!");
            userAnswer = Console.ReadLine();
        }

        var endOfMail = "";
        
        switch (userAnswer)
        {
            case "1":
            {
                endOfMail = "gmail.com";
                break;
            }
            case "2":
            {
                endOfMail = "yahoo.com";
                break;
            }
            case "3":
            {
                endOfMail = "outlook.com";
                break;
            }
            case "4":
            {
                endOfMail = "hotmail.com";
                break;
            }
            case "5":
            {
                endOfMail = "icloud.com";
                break;
            }
            case "6":
            {
                endOfMail = "protonmail.com";
                break;
            }
            case "7":
            {
                endOfMail = "aol.com";
                break;
            }
            case "8":
            {
                endOfMail = "mail.com";
                break;
            }
            case "9":
            {
                endOfMail = "zoho.com";
                break;
            }
            case "10":
            {
                endOfMail = "yandex.com";
                break;
            }
        }

        Console.WriteLine("Please enter name of your email (before @): ");
        var nameOfMail = Console.ReadLine();

        while (!_validation.IsCorrectMailName(nameOfMail))
        {
            Console.WriteLine("Invalid input, please try again");
            nameOfMail = Console.ReadLine();
        }
        
        return $"{nameOfMail}{endOfMail}";
    }
    
}
/*@gmail.com

@yahoo.com

@outlook.com

@hotmail.com

@icloud.com

@protonmail.com

@aol.com

@mail.com

@zoho.com

@yandex.com*/