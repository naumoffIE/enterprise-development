namespace FitnessClub.Domain;

public class Client : Person
{
    /// <summary>
    /// Класс данных для клиента фитнес клуба
    /// </summary>
    public required string PhoneNumber { get; set; }
    public DateOnly SubscriptionStart { get; set; }
    public DateOnly SubscriptionEnd { get; set; }
}