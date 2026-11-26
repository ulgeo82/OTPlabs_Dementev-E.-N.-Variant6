using ProjectWorkTimeAccounting.Entities;
using ProjectWorkTimeAccounting.Repositories;
using System.ComponentModel;

namespace ProjectWorkTimeAccounting.Forms;

// Создание и редактирование квалификации
public partial class FormQualification : Form
{
    private readonly IQualificationRepository _qualificationRepository;

    private int? _qualificationId;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Id
    {
        set
        {
            try
            {
                var qualification = _qualificationRepository.ReadQualificationById(value)
                    ?? throw new InvalidDataException(nameof(value));

                textBoxName.Text = qualification.Name;
                numericUpDownHourlyRate.Value = qualification.HourlyRate;
                _qualificationId = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public FormQualification(IQualificationRepository qualificationRepository)
    {
        InitializeComponent();
        _qualificationRepository = qualificationRepository ?? throw new ArgumentNullException(nameof(qualificationRepository));
    }

    private void ButtonSave_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || numericUpDownHourlyRate.Value <= 0)
            {
                throw new Exception("Имеются незаполненные поля");
            }

            if (_qualificationId.HasValue)
            {
                _qualificationRepository.UpdateQualification(CreateQualification(_qualificationId.Value));
            }
            else
            {
                _qualificationRepository.CreateQualification(CreateQualification(0));
            }

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonCancel_Click(object? sender, EventArgs e) => Close();

    private Qualification CreateQualification(int id) =>
        Qualification.CreateEntity(id, textBoxName.Text, numericUpDownHourlyRate.Value);
}
