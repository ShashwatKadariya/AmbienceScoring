using AmbienceScoring.Data;
using AmbienceScoring.Models;
using AmbienceScoring.Models.DTO;
using AmbienceScoring.Repository.IRepository;

namespace AmbienceScoring.Repository;

public class CategoryRepository: Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        this._db = db;
    }

    public async Task Update(Guid id, CategoryUpdateDTO category)
    {
        if (Guid.Empty.Equals(id))
        {
            throw new ArgumentException( $"Id field is null: {nameof(id)}");
            
        }

        var foundCategory = await _db.Categories.FindAsync(id);
        if (foundCategory == null)
        {
            throw new KeyNotFoundException($"Category with id {id} not found");
        }
        
        foundCategory.Name = category.Name;
        foundCategory.Parameters = category.Parameters;
        
        await _db.SaveChangesAsync();
    }
}