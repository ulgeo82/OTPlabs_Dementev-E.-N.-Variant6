using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting.Repositories;

// Репозиторий операции «Начисление заработной платы»
public interface ISalaryPaymentRepository
{
    IEnumerable<SalaryPayment> ReadSalaryPayments(DateTime? dateFrom = null, DateTime? dateTo = null,
        int? employeeId = null);

    void CreateSalaryPayment(SalaryPayment salaryPayment);
}
