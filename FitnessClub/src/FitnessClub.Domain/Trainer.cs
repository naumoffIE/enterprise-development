namespace FitnessClub.Domain;

public class Trainer : Person
{
    public Specialization Specialization { get; set; } = null!;
    public int Experience { get; set; }
}