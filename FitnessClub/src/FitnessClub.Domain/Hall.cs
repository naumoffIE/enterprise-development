namespace FitnessClub.Domain;
/// <summary>
/// Класс зала тренировок
/// </summary>
public class Hall
{
    /// <summary>
    /// ID зала
    /// </summary>
    public required int Id {get; set; } 
    /// <summary>
    /// Название зала
    /// </summary>
    public required string Name { get; set; }
}