namespace GymLog.API.Models.DTO;

public class UpdateExerciseRequestDto
{
    public string Name { get; set; }
    public string MuscleGroup { get; set; }
    public int DifficulityLevel { get; set; }
}