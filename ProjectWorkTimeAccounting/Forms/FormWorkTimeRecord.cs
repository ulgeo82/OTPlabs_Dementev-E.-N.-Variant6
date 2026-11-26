using ProjectWorkTimeAccounting.Entities;
using ProjectWorkTimeAccounting.Entities.Enums;
using ProjectWorkTimeAccounting.Repositories;
using ProjectWorkTimeAccounting.Repositories.Implementations;

namespace ProjectWorkTimeAccounting.Forms;

// Добавление записи учета рабочего времени
public partial class FormWorkTimeRecord : Form
{
    private readonly IWorkTimeRecordRepository _workTimeRecordRepository;

    public FormWorkTimeRecord(IWorkTimeRecordRepository workTimeRecordRepository,
        IEmployeeRepository employeeRepository, IProjectRepository projectRepository)
    {
        InitializeComponent();
        _workTimeRecordRepository = workTimeRecordRepository ?? throw new ArgumentNullException(nameof(workTimeRecordRepository));
        ArgumentNullException.ThrowIfNull(employeeRepository);
        ArgumentNullException.ThrowIfNull(projectRepository);

        comboBoxEmployee.DataSource = employeeRepository.ReadEmployees().ToList();
        comboBoxEmployee.DisplayMember = nameof(Employee.FullName);
        comboBoxEmployee.ValueMember = nameof(Employee.Id);

        foreach (var workKind in Enum.GetValues<WorkKind>().Where(x => x != WorkKind.None))
        {
            checkedListBoxWorkKinds.Items.Add(workKind);
        }

        ColumnProject.DataSource = projectRepository.ReadProjects().ToList();
        ColumnProject.DisplayMember = nameof(Project.Name);
        ColumnProject.ValueMember = nameof(Project.Id);
    }

    private void ButtonSave_Click(object? sender, EventArgs e)
    {
        try
        {
            if (comboBoxEmployee.SelectedIndex < 0
                || checkedListBoxWorkKinds.CheckedItems.Count == 0
                || dataGridViewProjects.RowCount < 2)
            {
                throw new Exception("Имеются незаполненные поля");
            }

            var workKind = WorkKind.None;
            foreach (var checkedItem in checkedListBoxWorkKinds.CheckedItems)
            {
                workKind |= (WorkKind)checkedItem;
            }

            var workTimeRecordProjects = CreateListWorkTimeRecordProjectsFromDataGrid();
            if (workTimeRecordProjects.Count == 0)
            {
                throw new Exception("Не указано ни одного проекта с отработанными часами");
            }

            _workTimeRecordRepository.CreateWorkTimeRecord(WorkTimeRecord.CreateOperation(0,
                (int)comboBoxEmployee.SelectedValue!, dateTimePickerWorkDate.Value.Date, workKind,
                workTimeRecordProjects));

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(DatabaseErrors.GetMessage(ex), "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonCancel_Click(object? sender, EventArgs e) => Close();

    private List<WorkTimeRecordProject> CreateListWorkTimeRecordProjectsFromDataGrid()
    {
        var list = new List<WorkTimeRecordProject>();
        foreach (DataGridViewRow row in dataGridViewProjects.Rows)
        {
            if (row.Cells["ColumnProject"].Value is not int projectId || row.Cells["ColumnHours"].Value is not object hoursValue)
            {
                continue;
            }

            if (!decimal.TryParse(hoursValue.ToString(), out var hours) || hours <= 0)
            {
                throw new Exception("Количество часов должно быть положительным числом");
            }

            list.Add(WorkTimeRecordProject.CreateElement(0, projectId, hours));
        }

        return list;
    }
}
