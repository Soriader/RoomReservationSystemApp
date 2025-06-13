using System.ComponentModel.DataAnnotations;

namespace RoomReservationSystemApp;

public class RoomReservationDB
{
    public RoomReservationDB(int number, string type, decimal basePrice, bool isAvailable)
    {
        Number = number;
        Type = type;
        BasePrice = basePrice;
        IsAvailable = isAvailable;
    }
    
    [Key]
    public int RoomId { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    [StringLength(20)]
    public string Type { get; set; }

    [Required]
    public decimal BasePrice { get; set; }

    public bool IsAvailable { get; set; } = true;
}