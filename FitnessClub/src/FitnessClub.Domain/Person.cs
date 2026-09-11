public abstract class Person
{
    public string PassportNumber { get; set; } = string.Empty;
    public string fullName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
}