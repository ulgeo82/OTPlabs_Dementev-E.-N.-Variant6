using System.ComponentModel;

namespace ProjectWorkTimeAccounting.Entities;

// Начисление заработной платы специалисту за месяц
public class SalaryPayment
{
    public int Id { get; private set; }

    [DisplayName("Специалист")]
    public int EmployeeId { get; private set; }

    [DisplayName("Расчетный месяц")]
    public DateTime PaymentMonth { get; private set; }

    [DisplayName("Отработано часов")]
    public decimal HoursWorked { get; private set; }

    [DisplayName("Сумма")]
    public decimal Amount { get; private set; }

    public static SalaryPayment CreateOperation(int id, int employeeId, DateTime paymentMonth,
        decimal hoursWorked, decimal amount)
    {
        return new SalaryPayment
        {
            Id = id,
            EmployeeId = employeeId,
            PaymentMonth = paymentMonth,
            HoursWorked = hoursWorked,
            Amount = amount
        };
    }
}
