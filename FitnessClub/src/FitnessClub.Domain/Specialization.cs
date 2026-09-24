namespace FitnessClub.Domain;
/// <summary>
/// Класс специализации тренера
/// </summary>
public class Specialization
{
    /// <summary>
    /// ID специализации
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название специализации
    /// </summary>
    public required string Name { get; set; }
}