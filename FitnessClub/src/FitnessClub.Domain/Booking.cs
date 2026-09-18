namespace FitnessClub.Domain;
/// <summary>
/// Класс для бронирования тренировок
/// </summary>
public class Booking
{
    public int ID { get; set; } 
    public required Client Client { get; set; }
    public required Trainer Trainer { get; set; }
    public required Hall Hall { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsTrial { get; set; }

    //в задании не было, но мне кажется стоит добавить
    public static readonly TimeSpan Duration = TimeSpan.FromHours(1);
}
