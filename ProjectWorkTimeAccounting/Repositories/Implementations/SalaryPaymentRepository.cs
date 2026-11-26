using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectWorkTimeAccounting.Entities;
using System.Text.Json;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Репозиторий операции «Начисление заработной платы» на Entity Framework Core
public class SalaryPaymentRepository : ISalaryPaymentRepository
{
    private readonly DataContext _context;

    private readonly ILogger<SalaryPaymentRepository> _logger;

    public SalaryPaymentRepository(DataContext context, ILogger<SalaryPaymentRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void CreateSalaryPayment(SalaryPayment salaryPayment)
    {
        _logger.LogInformation("Добавление объекта");
        _logger.LogDebug("Объект: {json}", JsonSerializer.Serialize(salaryPayment));

        try
        {
            _context.SalaryPayments.Add(salaryPayment);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Объект добавлен, идентификатор {id}", salaryPayment.Id);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при добавлении объекта");
            throw DatabaseErrors.Translate(ex);
        }
    }

    public IEnumerable<SalaryPayment> ReadSalaryPayments(DateTime? dateFrom = null, DateTime? dateTo = null,
        int? employeeId = null)
    {
        _logger.LogInformation("Получение всех объектов");
        _logger.LogDebug("Фильтр: {dateFrom}, {dateTo}, {employeeId}", dateFrom, dateTo, employeeId);

        try
        {
            var query = _context.SalaryPayments.AsNoTracking().AsQueryable();

            if (dateFrom.HasValue)
            {
                query = query.Where(x => x.PaymentMonth >= dateFrom.Value.Date);
            }
            if (dateTo.HasValue)
            {
                query = query.Where(x => x.PaymentMonth <= dateTo.Value.Date);
            }
            if (employeeId.HasValue)
            {
                query = query.Where(x => x.EmployeeId == employeeId.Value);
            }

            var salaryPayments = query.OrderByDescending(x => x.PaymentMonth).ThenBy(x => x.Id).ToList();
            _logger.LogDebug("Получено объектов: {count}", salaryPayments.Count);
            return salaryPayments;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при чтении объектов");
            throw DatabaseErrors.Translate(ex);
        }
    }
}
