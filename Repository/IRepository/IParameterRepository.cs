using AmbienceScoring.Models.DTO;

namespace AmbienceScoring.Repository.IRepository;

public interface IParameterRepository
{
    Task Update(Guid id, ParameterUpdateDTO parameter);
}