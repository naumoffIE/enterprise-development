namespace FitnessClub.Domain;
/// <summary>
/// Класс для представления человека
/// </summary>
public abstract class Person
{
    /// <summary>
    /// Номер паспорта
    /// </summary>
    public required string PassportNumber { get; set; }
    /// <summary>
    /// Полное имя
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly BirthDate { get; set; }
}