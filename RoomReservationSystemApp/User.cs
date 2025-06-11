namespace RoomReservationSystemApp;

public class User : IUser
{
    public int Id { get; }
    public string Name { get; }
    public string Email { get; }

    public int RentedRoomNumber { get; }


    public User(int id, string name, string email, int rentedRoomNumber)
    {
        Id = id;
        Name = name;
        Email = email;
        RentedRoomNumber = rentedRoomNumber;
    }
}