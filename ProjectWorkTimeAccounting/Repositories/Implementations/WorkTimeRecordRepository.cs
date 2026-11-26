using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectWorkTimeAccounting.Entities;
using System.Text.Json;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Репозиторий операции «Учет рабочего времени» на Entity Framework Core
public class WorkTimeRecordRepository : IWorkTimeRecordRepository
{
    private readonly DataContext _context;

    private readonly ILogger<WorkTimeRecordRepository> _logger;

    public WorkTimeRecordRepository(DataContext context, ILogger<WorkTimeRecordRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void CreateWorkTimeRecord(WorkTimeRecord workTimeRecord)
    {
        _logger.LogInformation("Добавление объекта");
        _logger.LogDebug("Объект: {json}", JsonSerializer.Serialize(workTimeRecord));

        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var newRecord = WorkTimeRecord.CreateOperation(0, workTimeRecord.EmployeeId, workTimeRecord.WorkDate,
                workTimeRecord.WorkKind, []);
            _context.WorkTimeRecords.Add(newRecord);
            _context.SaveChanges();

            foreach (var element in workTimeRecord.WorkTimeRecordProjects)
            {
                _context.WorkTimeRecordProjects.Add(
                    WorkTimeRecordProject.CreateElement(newRecord.Id, element.ProjectId, element.Hours));
            }
            _context.SaveChanges();

            transaction.Commit();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект добавлен, идентификатор {id}", newRecord.Id);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при добавлении объекта");
            throw DatabaseErrors.Translate(ex);
        }
    }

    public void DeleteWorkTimeRecord(int id)
    {
        _logger.LogInformation("Удаление объекта");
        _logger.LogDebug("Объект: {id}", id);

        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var elements = _context.WorkTimeRecordProjects.Where(x => x.WorkTimeRecordId == id).ToList();
            _context.WorkTimeRecordProjects.RemoveRange(elements);
            _context.SaveChanges();

            var workTimeRecord = _context.WorkTimeRecords.First(x => x.Id == id);
            _context.WorkTimeRecords.Remove(workTimeRecord);
            _context.SaveChanges();

            transaction.Commit();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект с идентификатором {id} удален", id);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при удалении объекта");
            throw DatabaseErrors.Translate(ex);
        }
    }

    public IEnumerable<WorkTimeRecord> ReadWorkTimeRecords(DateTime? dateFrom = null, DateTime? dateTo = null,
        int? employeeId = null, int? projectId = null)
    {
        _logger.LogInformation("Получение всех объектов");
        _logger.LogDebug("Фильтр: {dateFrom}, {dateTo}, {employeeId}, {projectId}", dateFrom, dateTo, employeeId, projectId);

        try
        {
            var query = _context.WorkTimeRecords
                .AsNoTracking()
                .Include(x => x.WorkTimeRecordProjects)
                .AsQueryable();

            if (dateFrom.HasValue)
            {
                query = query.Where(x => x.WorkDate >= dateFrom.Value.Date);
            }
            if (dateTo.HasValue)
            {
                query = query.Where(x => x.WorkDate <= dateTo.Value.Date);
            }
            if (employeeId.HasValue)
            {
                query = query.Where(x => x.EmployeeId == employeeId.Value);
            }
            if (projectId.HasValue)
            {
                query = query.Where(x => x.WorkTimeRecordProjects.Any(y => y.ProjectId == projectId.Value));
            }

            var workTimeRecords = query.OrderByDescending(x => x.WorkDate).ThenBy(x => x.Id).ToList();
            _logger.LogDebug("Получено объектов: {count}", workTimeRecords.Count);
            return workTimeRecords;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при чтении объектов");
            throw DatabaseErrors.Translate(ex);
        }
    }
}
