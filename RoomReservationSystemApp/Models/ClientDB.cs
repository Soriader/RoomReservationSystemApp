using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomReservationSystemApp;

public class ClientDB
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public int RoomReservationDBId { get; set; }

    [ForeignKey("RoomReservationDBId")]
    public RoomReservationDB RentedRoom { get; set; }
}