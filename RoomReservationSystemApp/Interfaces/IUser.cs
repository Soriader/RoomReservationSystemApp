namespace RoomReservationSystemApp;

public interface IUser
{
    int Id { get; }
    string Name { get; }
    string Email { get; }
    int RentedRoomNumber { get; }
}