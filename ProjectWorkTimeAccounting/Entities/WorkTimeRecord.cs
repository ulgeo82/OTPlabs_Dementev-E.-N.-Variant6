using ProjectWorkTimeAccounting.Entities.Enums;
using System.ComponentModel;

namespace ProjectWorkTimeAccounting.Entities;

// Запись учета рабочего времени специалиста за день
public class WorkTimeRecord
{
    public int Id { get; private set; }

    [DisplayName("Специалист")]
    public int EmployeeId { get; private set; }

    [DisplayName("Дата")]
    public DateTime WorkDate { get; private set; }

    [DisplayName("Виды работ")]
    public WorkKind WorkKind { get; private set; }

    [Browsable(false)]
    public IEnumerable<WorkTimeRecordProject> WorkTimeRecordProjects { get; private set; } = [];

    public static WorkTimeRecord CreateOperation(int id, int employeeId, DateTime workDate, WorkKind workKind,
        IEnumerable<WorkTimeRecordProject> workTimeRecordProjects)
    {
        return new WorkTimeRecord
        {
            Id = id,
            EmployeeId = employeeId,
            WorkDate = workDate,
            WorkKind = workKind,
            WorkTimeRecordProjects = workTimeRecordProjects ?? []
        };
    }
}
