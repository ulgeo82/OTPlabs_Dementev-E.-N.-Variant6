using ProjectWorkTimeAccounting.Entities;
using ProjectWorkTimeAccounting.Repositories;
using ProjectWorkTimeAccounting.Repositories.Implementations;

namespace ProjectWorkTimeAccounting.Forms;

// Добавление начисления заработной платы
public partial class FormSalaryPayment : Form
{
    private readonly ISalaryPaymentRepository _salaryPaymentRepository;

    public FormSalaryPayment(ISalaryPaymentRepository salaryPaymentRepository, IEmployeeRepository employeeRepository)
    {
        InitializeComponent();
        _salaryPaymentRepository = salaryPaymentRepository ?? throw new ArgumentNullException(nameof(salaryPaymentRepository));
        ArgumentNullException.ThrowIfNull(employeeRepository);

        comboBoxEmployee.DataSource = employeeRepository.ReadEmployees().ToList();
        comboBoxEmployee.DisplayMember = nameof(Employee.FullName);
        comboBoxEmployee.ValueMember = nameof(Employee.Id);
    }

    private void ButtonSave_Click(object? sender, EventArgs e)
    {
        try
        {
            if (comboBoxEmployee.SelectedIndex < 0
                || numericUpDownHoursWorked.Value <= 0
                || numericUpDownAmount.Value <= 0)
            {
                throw new Exception("Имеются незаполненные поля");
            }

            var paymentMonth = new DateTime(dateTimePickerPaymentMonth.Value.Year, dateTimePickerPaymentMonth.Value.Month, 1);

            _salaryPaymentRepository.CreateSalaryPayment(SalaryPayment.CreateOperation(0,
                (int)comboBoxEmployee.SelectedValue!, paymentMonth, numericUpDownHoursWorked.Value,
                numericUpDownAmount.Value));

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(DatabaseErrors.GetMessage(ex), "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonCancel_Click(object? sender, EventArgs e) => Close();
}
