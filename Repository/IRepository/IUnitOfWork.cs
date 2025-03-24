namespace AmbienceScoring.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository category { get; }
    IParameterRepository parameter { get; }
    IAssesmentRepository assesment { get; }
    Task Save();
}