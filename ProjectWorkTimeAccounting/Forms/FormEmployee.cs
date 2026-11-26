using ProjectWorkTimeAccounting.Entities;
using ProjectWorkTimeAccounting.Entities.Enums;
using ProjectWorkTimeAccounting.Repositories;
using System.ComponentModel;

namespace ProjectWorkTimeAccounting.Forms;

// Создание и редактирование специалиста
public partial class FormEmployee : Form
{
    private readonly IEmployeeRepository _employeeRepository;

    private int? _employeeId;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Id
    {
        set
        {
            try
            {
                var employee = _employeeRepository.ReadEmployeeById(value)
                    ?? throw new InvalidDataException(nameof(value));

                textBoxFullName.Text = employee.FullName;
                comboBoxPost.SelectedItem = employee.EmployeePost;
                comboBoxQualification.SelectedValue = employee.QualificationId;
                _employeeId = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public FormEmployee(IEmployeeRepository employeeRepository, IQualificationRepository qualificationRepository)
    {
        InitializeComponent();
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        ArgumentNullException.ThrowIfNull(qualificationRepository);

        comboBoxPost.DataSource = Enum.GetValues<EmployeePost>();

        comboBoxQualification.DataSource = qualificationRepository.ReadQualifications().ToList();
        comboBoxQualification.DisplayMember = nameof(Qualification.Name);
        comboBoxQualification.ValueMember = nameof(Qualification.Id);
    }

    private void ButtonSave_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(textBoxFullName.Text)
                || comboBoxPost.SelectedItem is not EmployeePost post || post == EmployeePost.None
                || comboBoxQualification.SelectedIndex < 0)
            {
                throw new Exception("Имеются незаполненные поля");
            }

            if (_employeeId.HasValue)
            {
                _employeeRepository.UpdateEmployee(CreateEmployee(_employeeId.Value, post));
            }
            else
            {
                _employeeRepository.CreateEmployee(CreateEmployee(0, post));
            }

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonCancel_Click(object? sender, EventArgs e) => Close();

    private Employee CreateEmployee(int id, EmployeePost post) =>
        Employee.CreateEntity(id, textBoxFullName.Text, post, (int)comboBoxQualification.SelectedValue!);

    private void textBoxFullName_TextChanged(object sender, EventArgs e)
    {

    }
}
