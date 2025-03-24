using System.ComponentModel.DataAnnotations;

namespace AmbienceScoring.Models;

public class Assesment
{
    [Key]
    public Guid Id { get; set; }
    
    public Guid ParameterId { get; set; }
    public Parameter parameter { get; set; }
    
    public int MaxScore { get; set; }
    public int ScoreObtained { get; set; }
    
    [EnumDataType(typeof(AchievementLevel))]
    public AchievementLevel achievementLevel { get; set; }
    
}