using System.ComponentModel.DataAnnotations;

namespace AmbienceScoring.Models.DTO;

public class CategoryUpdateDTO
{
    
    public Guid Id { get; set; }
    
    [
        Required, 
        MinLength(1, ErrorMessage="At-least 1 characters Required"), 
        MaxLength(1024,  ErrorMessage="Max Length should not exceed 30 characters")
    ]
    public string? Name { get; set; }
    
    public ICollection<Parameter>? Parameters { get; set; } = new List<Parameter>();
}