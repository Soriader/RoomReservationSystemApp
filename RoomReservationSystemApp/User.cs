namespace RoomReservationSystemApp;

public class User : IUser
{
    public int Id { get; }
    public string Name { get; }
    public string Email { get; }

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}