using ProjectWorkTimeAccounting.Repositories;
using Unity;

namespace ProjectWorkTimeAccounting.Forms;

// Список операций «Начисление заработной платы»
public partial class FormSalaryPayments : Form
{
    private readonly IUnityContainer _container;

    private readonly ISalaryPaymentRepository _salaryPaymentRepository;

    public FormSalaryPayments(IUnityContainer container, ISalaryPaymentRepository salaryPaymentRepository)
    {
        InitializeComponent();
        _container = container ?? throw new ArgumentNullException(nameof(container));
        _salaryPaymentRepository = salaryPaymentRepository ?? throw new ArgumentNullException(nameof(salaryPaymentRepository));
    }

    private void FormSalaryPayments_Load(object? sender, EventArgs e)
    {
        try
        {
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            _container.Resolve<FormSalaryPayment>().ShowDialog();
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadList() => dataGridViewData.DataSource = _salaryPaymentRepository.ReadSalaryPayments().ToList();
}
