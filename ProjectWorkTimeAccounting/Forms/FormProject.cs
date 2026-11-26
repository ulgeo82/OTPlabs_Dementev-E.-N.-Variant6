using ProjectWorkTimeAccounting.Entities;
using ProjectWorkTimeAccounting.Entities.Enums;
using ProjectWorkTimeAccounting.Repositories;
using System.ComponentModel;

namespace ProjectWorkTimeAccounting.Forms;

// Создание и редактирование проекта
public partial class FormProject : Form
{
    private readonly IProjectRepository _projectRepository;

    private int? _projectId;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Id
    {
        set
        {
            try
            {
                var project = _projectRepository.ReadProjectById(value)
                    ?? throw new InvalidDataException(nameof(value));

                textBoxName.Text = project.Name;
                comboBoxProjectType.SelectedItem = project.ProjectType;
                comboBoxManager.SelectedValue = project.ManagerId;
                comboBoxDeveloper.SelectedValue = project.DeveloperId;
                dateTimePickerStartDate.Value = project.StartDate;
                _projectId = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public FormProject(IProjectRepository projectRepository, IEmployeeRepository employeeRepository)
    {
        InitializeComponent();
        _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        ArgumentNullException.ThrowIfNull(employeeRepository);

        comboBoxProjectType.DataSource = Enum.GetValues<ProjectType>();

        var employees = employeeRepository.ReadEmployees().ToList();

        comboBoxManager.DataSource = employees.Where(x => x.EmployeePost == EmployeePost.Manager).ToList();
        comboBoxManager.DisplayMember = nameof(Employee.FullName);
        comboBoxManager.ValueMember = nameof(Employee.Id);

        comboBoxDeveloper.DataSource = employees.Where(x => x.EmployeePost == EmployeePost.Developer).ToList();
        comboBoxDeveloper.DisplayMember = nameof(Employee.FullName);
        comboBoxDeveloper.ValueMember = nameof(Employee.Id);
    }

    private void ButtonSave_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text)
                || comboBoxProjectType.SelectedItem is not ProjectType projectType || projectType == ProjectType.None
                || comboBoxManager.SelectedIndex < 0
                || comboBoxDeveloper.SelectedIndex < 0)
            {
                throw new Exception("Имеются незаполненные поля");
            }

            if (_projectId.HasValue)
            {
                _projectRepository.UpdateProject(CreateProject(_projectId.Value, projectType));
            }
            else
            {
                _projectRepository.CreateProject(CreateProject(0, projectType));
            }

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonCancel_Click(object? sender, EventArgs e) => Close();

    private Project CreateProject(int id, ProjectType projectType) =>
        Project.CreateEntity(id, textBoxName.Text, projectType, (int)comboBoxManager.SelectedValue!,
            (int)comboBoxDeveloper.SelectedValue!, dateTimePickerStartDate.Value);
}
