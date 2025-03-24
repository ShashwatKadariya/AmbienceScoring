using AmbienceScoring.Data;
using AmbienceScoring.Models;
using AmbienceScoring.Models.DTO;
using AmbienceScoring.Repository.IRepository;

namespace AmbienceScoring.Repository;

public class ParameterRepository: Repository<Parameter>, IParameterRepository
{
    private ApplicationDbContext _db;
    public ParameterRepository(ApplicationDbContext db) : base(db)
    {
        this._db = db;
    }

    public async Task Update(Guid id, ParameterUpdateDTO parameter)
    {
        if (Guid.Empty.Equals(id))
        {
            throw new ArgumentException( $"Id field is null: {nameof(id)}");
            
        }

        var foundParameter = await _db.Parameters.FindAsync(id);
        if (foundParameter == null)
        {
            throw new KeyNotFoundException($"Category with id {id} not found");
        }
        
        foundParameter.Description = parameter.Description;
        foundParameter.Category = parameter.Category;
        foundParameter.CategoryId = parameter.Category.Id;
        
        await _db.SaveChangesAsync();
    }
}