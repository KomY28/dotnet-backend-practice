namespace GymLog.API.Models.Domain;

public class WorkOutLog
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public int WeightInKg { get; set; }
    public int Reps { get; set; }
    
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
}