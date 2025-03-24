using System.ComponentModel.DataAnnotations;

namespace AmbienceScoring.Models.DTO;

public class ParameterUpdateDTO
{
    public Guid Id { get; set; }
    
    [
        Required, 
        MinLength(1, ErrorMessage="At-least 1 characters Required"), 
        MaxLength(1024,  ErrorMessage="Max Length should not exceed 30 characters")
    ]
    public string? Description { get; set; }
    
    [Required]
    public Guid CategoryId { get; set; }
    
    [Required]
    public Category Category { get; set; }
    
    public ICollection<Assesment> Assesments { get; set; } = new List<Assesment>();
}