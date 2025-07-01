namespace RoomReservationSystemApp;

public class User : IUser
{
    public string Name { get; }
    public string Email { get; }
    

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}