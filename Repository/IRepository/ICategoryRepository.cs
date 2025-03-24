using AmbienceScoring.Models;
using AmbienceScoring.Models.DTO;

namespace AmbienceScoring.Repository.IRepository;

public interface ICategoryRepository
{
    Task Update(Guid id, CategoryUpdateDTO category);
}