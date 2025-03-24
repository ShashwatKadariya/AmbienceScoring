using AmbienceScoring.Data;
using AmbienceScoring.Models;
using AmbienceScoring.Models.DTO;
using AmbienceScoring.Repository.IRepository;

namespace AmbienceScoring.Repository;

public class AssesmentRepository: Repository<Assesment>, IAssesmentRepository
{
    private ApplicationDbContext _db;

    public AssesmentRepository(ApplicationDbContext db) : base(db)
    {
        this._db = db;
    }

    public Task Update(Guid id, AssesmentUpdateDTO assesment)
    {
        throw new NotImplementedException();
    }
}