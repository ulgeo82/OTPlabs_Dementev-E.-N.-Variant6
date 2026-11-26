using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Заглушка репозитория операции «Начисление заработной платы»
public class SalaryPaymentRepository : ISalaryPaymentRepository
{
    public void CreateSalaryPayment(SalaryPayment salaryPayment)
    {
    }

    public IEnumerable<SalaryPayment> ReadSalaryPayments(DateTime? dateFrom = null, DateTime? dateTo = null,
        int? employeeId = null)
    {
        return [];
    }
}
