using System.ComponentModel.DataAnnotations;

namespace AmbienceScoring.Models;

public class Parameter
{
    [Key]
    public Guid Id { get; set; }
    
    [
        Required, 
        MinLength(1, ErrorMessage="At-least 1 characters Required"), 
        MaxLength(1024,  ErrorMessage="Max Length should not exceed 30 characters")
    ]
    public string? Description { get; set; }
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    
    [Required]
    public ICollection<Assesment> Assesments { get; set; } = new List<Assesment>();
}