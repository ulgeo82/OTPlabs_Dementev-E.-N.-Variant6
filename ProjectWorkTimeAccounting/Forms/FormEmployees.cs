using ProjectWorkTimeAccounting.Repositories;
using Unity;

namespace ProjectWorkTimeAccounting.Forms;

// Список справочника «Специалисты»
public partial class FormEmployees : Form
{
    private readonly IUnityContainer _container;

    private readonly IEmployeeRepository _employeeRepository;

    public FormEmployees(IUnityContainer container, IEmployeeRepository employeeRepository)
    {
        InitializeComponent();
        _container = container ?? throw new ArgumentNullException(nameof(container));
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }

    private void FormEmployees_Load(object? sender, EventArgs e)
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
            _container.Resolve<FormEmployee>().ShowDialog();
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonUpdate_Click(object? sender, EventArgs e)
    {
        if (!TryGetIdentifierFromSelectedRow(out var findId))
        {
            return;
        }

        try
        {
            var form = _container.Resolve<FormEmployee>();
            form.Id = findId;
            form.ShowDialog();
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при изменении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonDelete_Click(object? sender, EventArgs e)
    {
        if (!TryGetIdentifierFromSelectedRow(out var findId))
        {
            return;
        }

        if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        try
        {
            _employeeRepository.DeleteEmployee(findId);
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadList() => dataGridViewData.DataSource = _employeeRepository.ReadEmployees().ToList();

    private bool TryGetIdentifierFromSelectedRow(out int id)
    {
        id = 0;
        if (dataGridViewData.SelectedRows.Count < 1)
        {
            MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        id = Convert.ToInt32(dataGridViewData.SelectedRows[0].Cells["Id"].Value);
        return true;
    }
}
