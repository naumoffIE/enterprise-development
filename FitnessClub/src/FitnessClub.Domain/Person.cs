namespace FitnessClub.Domain;

public abstract class Person
{
    public required string PassportNumber { get; set; }
    public required string FullName { get; set; }
    public Gender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
}