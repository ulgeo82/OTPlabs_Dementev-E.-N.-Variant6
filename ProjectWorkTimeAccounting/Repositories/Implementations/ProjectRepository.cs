using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectWorkTimeAccounting.Entities;
using System.Text.Json;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Репозиторий справочника «Проекты» на Entity Framework Core
public class ProjectRepository : IProjectRepository
{
    private readonly DataContext _context;

    private readonly ILogger<ProjectRepository> _logger;

    public ProjectRepository(DataContext context, ILogger<ProjectRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void CreateProject(Project project)
    {
        _logger.LogInformation("Добавление объекта");
        _logger.LogDebug("Объект: {json}", JsonSerializer.Serialize(project));

        try
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект добавлен, идентификатор {id}", project.Id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при добавлении объекта");
            throw;
        }
    }

    public void UpdateProject(Project project)
    {
        _logger.LogInformation("Редактирование объекта");
        _logger.LogDebug("Объект: {json}", JsonSerializer.Serialize(project));

        try
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект с идентификатором {id} изменен", project.Id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при редактировании объекта");
            throw;
        }
    }

    public void DeleteProject(int id)
    {
        _logger.LogInformation("Удаление объекта");
        _logger.LogDebug("Объект: {id}", id);

        try
        {
            var project = _context.Projects.First(x => x.Id == id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект с идентификатором {id} удален", id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при удалении объекта");
            throw;
        }
    }

    public Project ReadProjectById(int id)
    {
        _logger.LogInformation("Получение объекта по идентификатору");
        _logger.LogDebug("Объект: {id}", id);

        try
        {
            var project = _context.Projects.AsNoTracking().First(x => x.Id == id);
            _logger.LogDebug("Найденный объект: {json}", JsonSerializer.Serialize(project));
            return project;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при поиске объекта");
            throw;
        }
    }

    public IEnumerable<Project> ReadProjects()
    {
        _logger.LogInformation("Получение всех объектов");

        try
        {
            var projects = _context.Projects.AsNoTracking().OrderBy(x => x.Name).ToList();
            _logger.LogDebug("Получено объектов: {count}", projects.Count);
            return projects;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при чтении объектов");
            throw;
        }
    }
}
