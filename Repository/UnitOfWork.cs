using AmbienceScoring.Data;
using AmbienceScoring.Repository.IRepository;

namespace AmbienceScoring.Repository;

public class UnitOfWork: IUnitOfWork
{
    private ApplicationDbContext _db;

    public ICategoryRepository category { get; }
    public IParameterRepository parameter { get; }
    public IAssesmentRepository assesment { get; }

    public UnitOfWork(
        ApplicationDbContext db, 
        ICategoryRepository category, 
        IParameterRepository parameter,
        IAssesmentRepository assesment
        )
    {
        this._db = db;
        this.category = category;
        this.parameter = parameter;
        this.assesment = assesment;
    }

    public async Task Save()
    {
       await _db.SaveChangesAsync();
    }
}