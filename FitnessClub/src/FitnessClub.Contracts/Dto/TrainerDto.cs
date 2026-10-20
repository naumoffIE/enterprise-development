namespace FitnessClub.Contracts.Dto;
public class TrainerDto
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Specialization { get; set; } 
    public int Experience { get; set; }
}