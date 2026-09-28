namespace FitnessClub.Domain;
/// <summary>
/// Класс для бронирования тренировок
/// </summary>
public class Booking
{
    /// <summary>
    /// ID брони
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Клиент, забронировавший тренировку
    /// </summary>
    public required Client Client { get; set; }
    /// <summary>
    /// Тренер, на которого забронирована тренировка
    /// </summary>
    public required Trainer Trainer { get; set; }
    /// <summary>
    /// Зал, в котором будет проводиться тренировка
    /// </summary>
    public required Hall Hall { get; set; }
    /// <summary>
    /// Дата и время тренировки
    /// </summary>
    public DateTime DateTime { get; set; }
    /// <summary>
    /// Является ли тренировка пробной
    /// </summary>
    public bool IsTrial { get; set; }

    /// <summary>
    /// Длительность тренировки (1 час сделал)
    /// </summary>
    /// <remarks>
    /// потом будет не статик
    /// </remarks>
    public static readonly TimeSpan Duration = TimeSpan.FromHours(1);
}
