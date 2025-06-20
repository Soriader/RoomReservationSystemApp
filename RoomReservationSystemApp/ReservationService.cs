namespace RoomReservationSystemApp;

public class ReservationService
{
    private readonly Validation _validation;
    private readonly IRoom _room;
    private readonly Room _reservationRoom;
    private readonly RoomReservationRepository _repository;
    private readonly RoomService _roomService;

    
    public ReservationService(Validation validation, RoomReservationRepository repository, IRoom room, Room reservationRoom)
    {
        _validation = validation;
        _repository = repository;
        _room = room;
        _reservationRoom = reservationRoom;
    }

    public IRoom Reservation(int roomNumber)
    {
        _roomService.ShowRoomsByNumber(roomNumber);

        return null;
    }
}