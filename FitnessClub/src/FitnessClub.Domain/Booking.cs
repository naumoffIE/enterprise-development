namespace FitnessClub.Domain;

public class Booking
{
    /// <summary>
    /// Класс для бронирования тренировок
    /// </summary>
    public int ID { get; set; } 
    public Client Client { get; set; } = null!;
    public Trainer Trainer { get; set; } = null!;
    public Hall Hall { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public bool IsTrial { get; set; }

    //в задании не было, но мне кажется стоит добавить
    public static readonly TimeSpan Duration = TimeSpan.FromHours(1);
}
