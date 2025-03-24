using AmbienceScoring.Models.DTO;

namespace AmbienceScoring.Repository.IRepository;

public interface IAssesmentRepository
{
    Task Update(Guid id, AssesmentUpdateDTO assesment);
}