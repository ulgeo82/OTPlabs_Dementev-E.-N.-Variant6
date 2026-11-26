using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkTimeAccounting.Entities;

// Начисление заработной платы специалисту за месяц
[Table("salary_payments")]
public class SalaryPayment
{
    [Key]
    [Column("id")]
    public int Id { get; private set; }

    [Column("employee_id")]
    [ForeignKey(nameof(Employee))]
    [DisplayName("Специалист")]
    public int EmployeeId { get; private set; }

    [Column("payment_month", TypeName = "date")]
    [DisplayName("Расчетный месяц")]
    public DateTime PaymentMonth { get; private set; }

    [Column("hours_worked", TypeName = "numeric(6,2)")]
    [DisplayName("Отработано часов")]
    public decimal HoursWorked { get; private set; }

    [Column("amount", TypeName = "numeric(12,2)")]
    [DisplayName("Сумма")]
    public decimal Amount { get; private set; }

    [Browsable(false)]
    public Employee? Employee { get; private set; }

    public static SalaryPayment CreateOperation(int id, int employeeId, DateTime paymentMonth,
        decimal hoursWorked, decimal amount)
    {
        return new SalaryPayment
        {
            Id = id,
            EmployeeId = employeeId,
            PaymentMonth = paymentMonth.Date,
            HoursWorked = hoursWorked,
            Amount = amount
        };
    }
}
