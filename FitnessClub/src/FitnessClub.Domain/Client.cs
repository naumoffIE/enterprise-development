namespace FitnessClub.Domain;
/// <summary>
/// Класс данных для клиента фитнес клуба
/// </summary>
public class Client : Person
{
    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public required string PhoneNumber { get; set; }
    /// <summary>
    /// Начало абонемента
    /// </summary>
    public DateOnly SubscriptionStart { get; set; }
    /// <summary>
    /// Окончание абонемента
    /// </summary>
    public DateOnly SubscriptionEnd { get; set; }
}