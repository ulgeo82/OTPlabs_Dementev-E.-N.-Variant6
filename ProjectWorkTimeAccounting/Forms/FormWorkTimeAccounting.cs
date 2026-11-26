using Unity;

namespace ProjectWorkTimeAccounting.Forms;

// Главная форма приложения
public partial class FormWorkTimeAccounting : Form
{
    private readonly IUnityContainer _container;

    public FormWorkTimeAccounting(IUnityContainer container)
    {
        InitializeComponent();
        _container = container ?? throw new ArgumentNullException(nameof(container));
    }

    private void ToolStripMenuItemQualifications_Click(object? sender, EventArgs e) => ShowForm<FormQualifications>();

    private void ToolStripMenuItemEmployees_Click(object? sender, EventArgs e) => ShowForm<FormEmployees>();

    private void ToolStripMenuItemProjects_Click(object? sender, EventArgs e) => ShowForm<FormProjects>();

    private void ToolStripMenuItemWorkTimeRecords_Click(object? sender, EventArgs e) => ShowForm<FormWorkTimeRecords>();

    private void ToolStripMenuItemSalaryPayments_Click(object? sender, EventArgs e) => ShowForm<FormSalaryPayments>();

    private void ShowForm<T>() where T : Form
    {
        try
        {
            _container.Resolve<T>().ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
