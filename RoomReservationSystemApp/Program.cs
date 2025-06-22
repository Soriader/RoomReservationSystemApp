using RoomReservationSystemApp;

var validation = new Validation();
var repository = new RoomReservationRepository();
var roomService = new RoomService(validation, repository);
var adminPanel = new AdminPanel(roomService);
var reservationService = new ReservationService(validation, repository, roomService);

reservationService.BookARoom();
//adminPanel.AddNewRoom();