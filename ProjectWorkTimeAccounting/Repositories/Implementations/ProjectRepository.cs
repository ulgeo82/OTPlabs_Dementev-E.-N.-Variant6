using ProjectWorkTimeAccounting.Entities;
using ProjectWorkTimeAccounting.Entities.Enums;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Заглушка репозитория справочника «Проекты»
public class ProjectRepository : IProjectRepository
{
    public void CreateProject(Project project)
    {
    }

    public void DeleteProject(int id)
    {
    }

    public Project ReadProjectById(int id)
    {
        return Project.CreateEntity(0, string.Empty, ProjectType.None, 0, 0, DateTime.Now);
    }

    public IEnumerable<Project> ReadProjects()
    {
        return [];
    }

    public void UpdateProject(Project project)
    {
    }
}
