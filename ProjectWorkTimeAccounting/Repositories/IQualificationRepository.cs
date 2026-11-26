using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting.Repositories;

// Репозиторий справочника «Квалификации»
public interface IQualificationRepository
{
    IEnumerable<Qualification> ReadQualifications();

    Qualification ReadQualificationById(int id);

    void CreateQualification(Qualification qualification);

    void UpdateQualification(Qualification qualification);

    void DeleteQualification(int id);
}
