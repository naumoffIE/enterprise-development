namespace FitnessClub.Domain;

public class Trainer : Person
{
    /// <summary>
    /// Класс данных для тренера фитнес клуба
    /// </summary>
    public Specialization Specialization { get; set; } = null!;
    public int Experience { get; set; }
}