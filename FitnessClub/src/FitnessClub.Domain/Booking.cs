public class Booking
{
    public Client Client { get; set; } = null!;
    public Trainer Trainer { get; set; } = null!;
    public Hall Hall { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public bool IsTrial { get; set; }

}