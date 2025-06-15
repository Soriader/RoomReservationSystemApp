using RoomReservationSystemApp;

var validation = new Validation();
var repository = new RoomReservationRepository();
var roomService = new RoomService(validation, repository);
var adminPanel = new AdminPanel(roomService);

adminPanel.AddNewRoom();