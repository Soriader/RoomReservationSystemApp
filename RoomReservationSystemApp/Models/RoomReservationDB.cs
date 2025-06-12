using System.ComponentModel.DataAnnotations;

namespace RoomReservationSystemApp;

public class RoomReservationDB
{

    public RoomReservationDB(int number, string type, bool isAvailable)
    {
        Number = number;
        Type = type;
        IsAvailable = isAvailable;
    }
    
    [Key]
    public int RoomId { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    [StringLength(20)]
    public string Type { get; set; }

    public bool IsAvailable { get; set; } = true;
}