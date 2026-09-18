namespace FitnessClub.Domain;
/// <summary>
/// Класс данных для тренера фитнес клуба
/// </summary>
public class Trainer : Person
{
    public required Specialization Specialization { get; set; }
    public int Experience { get; set; }
}