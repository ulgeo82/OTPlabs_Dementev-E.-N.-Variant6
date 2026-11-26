using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting.Repositories;

// Репозиторий справочника «Проекты»
public interface IProjectRepository
{
    IEnumerable<Project> ReadProjects();

    Project ReadProjectById(int id);

    void CreateProject(Project project);

    void UpdateProject(Project project);

    void DeleteProject(int id);
}
