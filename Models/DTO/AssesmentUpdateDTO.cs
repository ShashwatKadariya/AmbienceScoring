using System.ComponentModel.DataAnnotations;

namespace AmbienceScoring.Models.DTO;

public class AssesmentUpdateDTO
{
    
    public Guid Id { get; set; }
    
    [Required]
    public Guid ParameterId { get; set; }
    [Required]
    public Parameter parameter { get; set; }
    
    [
        Required,
        Range(1, 10, ErrorMessage = "Max Score must be in the range 1-10")
    ]
    public int MaxScore { get; set; }
    
    [
        Required,
        Range(1, 10, ErrorMessage = "Obtained Score must be in the range 1-10")
    ]
    public int ScoreObtained { get; set; }
    
    [EnumDataType(typeof(AchievementLevel))]
    public AchievementLevel achievementLevel { get; set; }
}