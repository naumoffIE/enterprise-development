namespace FitnessClub.Domain;
/// <summary>
/// Класс данных для клиента фитнес клуба
/// </summary>
public class Client : Person
{
    public required string PhoneNumber { get; set; }
    public DateOnly SubscriptionStart { get; set; }
    public DateOnly SubscriptionEnd { get; set; }
}