public class Client : Person
{
    public required string PhoneNumber { get; set; }
    public DateOnly SubscriptionStart { get; set; }
    public DateOnly SubscriptionEnd { get; set; }
}