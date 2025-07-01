namespace RoomReservationSystemApp;

public interface IClient<T> where T : class 
{
    public int Id { get; set; }

    public User User { get; set; }
    
    public string Email { get; set; }

    public int RoomReservationDBId { get; set; }

    public RoomReservationDB RentedRoom { get; set; }
}