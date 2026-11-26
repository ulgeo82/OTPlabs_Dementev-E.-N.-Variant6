using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Заглушка репозитория операции «Учет рабочего времени»
public class WorkTimeRecordRepository : IWorkTimeRecordRepository
{
    public void CreateWorkTimeRecord(WorkTimeRecord workTimeRecord)
    {
    }

    public void DeleteWorkTimeRecord(int id)
    {
    }

    public IEnumerable<WorkTimeRecord> ReadWorkTimeRecords(DateTime? dateFrom = null, DateTime? dateTo = null,
        int? employeeId = null, int? projectId = null)
    {
        return [];
    }
}
