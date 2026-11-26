using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectWorkTimeAccounting.Entities;
using System.Text.Json;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Репозиторий справочника «Квалификации» на Entity Framework Core
public class QualificationRepository : IQualificationRepository
{
    private readonly DataContext _context;

    private readonly ILogger<QualificationRepository> _logger;

    public QualificationRepository(DataContext context, ILogger<QualificationRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void CreateQualification(Qualification qualification)
    {
        _logger.LogInformation("Добавление объекта");
        _logger.LogDebug("Объект: {json}", JsonSerializer.Serialize(qualification));

        try
        {
            _context.Qualifications.Add(qualification);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект добавлен, идентификатор {id}", qualification.Id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при добавлении объекта");
            throw;
        }
    }

    public void UpdateQualification(Qualification qualification)
    {
        _logger.LogInformation("Редактирование объекта");
        _logger.LogDebug("Объект: {json}", JsonSerializer.Serialize(qualification));

        try
        {
            _context.Qualifications.Update(qualification);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект с идентификатором {id} изменен", qualification.Id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при редактировании объекта");
            throw;
        }
    }

    public void DeleteQualification(int id)
    {
        _logger.LogInformation("Удаление объекта");
        _logger.LogDebug("Объект: {id}", id);

        try
        {
            var qualification = _context.Qualifications.First(x => x.Id == id);
            _context.Qualifications.Remove(qualification);
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

    public Qualification ReadQualificationById(int id)
    {
        _logger.LogInformation("Получение объекта по идентификатору");
        _logger.LogDebug("Объект: {id}", id);

        try
        {
            var qualification = _context.Qualifications.AsNoTracking().First(x => x.Id == id);
            _logger.LogDebug("Найденный объект: {json}", JsonSerializer.Serialize(qualification));
            return qualification;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при поиске объекта");
            throw;
        }
    }

    public IEnumerable<Qualification> ReadQualifications()
    {
        _logger.LogInformation("Получение всех объектов");

        try
        {
            var qualifications = _context.Qualifications.AsNoTracking().OrderBy(x => x.Name).ToList();
            _logger.LogDebug("Получено объектов: {count}", qualifications.Count);
            return qualifications;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при чтении объектов");
            throw;
        }
    }
}
