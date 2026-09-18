namespace FitnessClub.Domain;
/// <summary>
/// Класс для представления человека
/// </summary>
public abstract class Person
{
    public required string PassportNumber { get; set; }
    public required string FullName { get; set; }
    public Gender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
}