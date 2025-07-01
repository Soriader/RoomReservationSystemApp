namespace RoomReservationSystemApp;

public class AdminPanel
{
    private readonly IRoomService _roomService;

    public AdminPanel(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public void AddNewRoom()
    {
        var room = _roomService.AddNewRoom();
        Console.WriteLine($"Room added: {room.Number}, {room.Type}");
    }
}