using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectWorkTimeAccounting.Entities;
using System.Text.Json;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Репозиторий справочника «Специалисты» на Entity Framework Core
public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;

    private readonly ILogger<EmployeeRepository> _logger;

    public EmployeeRepository(DataContext context, ILogger<EmployeeRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void CreateEmployee(Employee employee)
    {
        _logger.LogInformation("Добавление объекта");
        _logger.LogDebug("Объект: {json}", JsonSerializer.Serialize(employee));

        try
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект добавлен, идентификатор {id}", employee.Id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при добавлении объекта");
            throw DatabaseErrors.Translate(ex);
        }
    }

    public void UpdateEmployee(Employee employee)
    {
        _logger.LogInformation("Редактирование объекта");
        _logger.LogDebug("Объект: {json}", JsonSerializer.Serialize(employee));

        try
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект с идентификатором {id} изменен", employee.Id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при редактировании объекта");
            throw DatabaseErrors.Translate(ex);
        }
    }

    public void DeleteEmployee(int id)
    {
        _logger.LogInformation("Удаление объекта");
        _logger.LogDebug("Объект: {id}", id);

        try
        {
            var employee = _context.Employees.First(x => x.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект с идентификатором {id} удален", id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при удалении объекта");
            throw DatabaseErrors.Translate(ex);
        }
    }

    public Employee ReadEmployeeById(int id)
    {
        _logger.LogInformation("Получение объекта по идентификатору");
        _logger.LogDebug("Объект: {id}", id);

        try
        {
            var employee = _context.Employees.AsNoTracking().First(x => x.Id == id);
            _logger.LogDebug("Найденный объект: {json}", JsonSerializer.Serialize(employee));
            return employee;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при поиске объекта");
            throw DatabaseErrors.Translate(ex);
        }
    }

    public IEnumerable<Employee> ReadEmployees()
    {
        _logger.LogInformation("Получение всех объектов");

        try
        {
            var employees = _context.Employees.AsNoTracking().OrderBy(x => x.FullName).ToList();
            _logger.LogDebug("Получено объектов: {count}", employees.Count);
            return employees;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при чтении объектов");
            throw DatabaseErrors.Translate(ex);
        }
    }
}
