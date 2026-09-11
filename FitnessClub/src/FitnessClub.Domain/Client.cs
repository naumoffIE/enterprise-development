public class Client : Person
{
    public string PhoneNumber { get; set; } = string.Empty;
    public DateOnly SubscriptionStart { get; set; }
    public DateOnly SubscriptionEnd { get; set; }
}