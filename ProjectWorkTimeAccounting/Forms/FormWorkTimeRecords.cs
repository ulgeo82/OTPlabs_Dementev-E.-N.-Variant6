using ProjectWorkTimeAccounting.Repositories;
using ProjectWorkTimeAccounting.Repositories.Implementations;
using Unity;

namespace ProjectWorkTimeAccounting.Forms;

// Список операций «Учет рабочего времени»
public partial class FormWorkTimeRecords : Form
{
    private readonly IUnityContainer _container;

    private readonly IWorkTimeRecordRepository _workTimeRecordRepository;

    public FormWorkTimeRecords(IUnityContainer container, IWorkTimeRecordRepository workTimeRecordRepository)
    {
        InitializeComponent();
        _container = container ?? throw new ArgumentNullException(nameof(container));
        _workTimeRecordRepository = workTimeRecordRepository ?? throw new ArgumentNullException(nameof(workTimeRecordRepository));
    }

    private void FormWorkTimeRecords_Load(object? sender, EventArgs e)
    {
        try
        {
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(DatabaseErrors.GetMessage(ex), "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            _container.Resolve<FormWorkTimeRecord>().ShowDialog();
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(DatabaseErrors.GetMessage(ex), "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _workTimeRecordRepository.DeleteWorkTimeRecord(findId);
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(DatabaseErrors.GetMessage(ex), "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadList() => dataGridViewData.DataSource = _workTimeRecordRepository.ReadWorkTimeRecords().ToList();

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
