namespace GymLog.API.Models.Domain;

public class Exercise
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MuscleGroup { get; set; }
    public int DifficulityLevel { get; set; }
}