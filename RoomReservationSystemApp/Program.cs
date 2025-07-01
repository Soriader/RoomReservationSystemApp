using RoomReservationSystemApp;

var validation = new Validation();
var repository = new RoomReservationRepository();
var roomService = new RoomService(validation, repository);
var adminPanel = new AdminPanel(roomService);
var reservationService = new ReservationService(validation, repository, roomService);
var clientRepository = new ClientRepository();
var registerService = new RegisterService(validation, clientRepository);

//reservationService.BookARoom();
//adminPanel.AddNewRoom();
registerService.CreateAccount();