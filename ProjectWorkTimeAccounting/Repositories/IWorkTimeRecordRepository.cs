using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting.Repositories;

// Репозиторий операции «Учет рабочего времени»
public interface IWorkTimeRecordRepository
{
    IEnumerable<WorkTimeRecord> ReadWorkTimeRecords(DateTime? dateFrom = null, DateTime? dateTo = null,
        int? employeeId = null, int? projectId = null);

    void CreateWorkTimeRecord(WorkTimeRecord workTimeRecord);

    void DeleteWorkTimeRecord(int id);
}
