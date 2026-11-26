using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Заглушка репозитория справочника «Квалификации»
public class QualificationRepository : IQualificationRepository
{
    public void CreateQualification(Qualification qualification)
    {
    }

    public void DeleteQualification(int id)
    {
    }

    public Qualification ReadQualificationById(int id)
    {
        return Qualification.CreateEntity(0, string.Empty, 0);
    }

    public IEnumerable<Qualification> ReadQualifications()
    {
        return [];
    }

    public void UpdateQualification(Qualification qualification)
    {
    }
}
