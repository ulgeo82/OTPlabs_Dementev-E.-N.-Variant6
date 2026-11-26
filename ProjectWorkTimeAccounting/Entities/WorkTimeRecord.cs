using ProjectWorkTimeAccounting.Entities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkTimeAccounting.Entities;

// Запись учета рабочего времени специалиста за день
[Table("work_time_records")]
public class WorkTimeRecord
{
    [Key]
    [Column("id")]
    public int Id { get; private set; }

    [Column("employee_id")]
    [ForeignKey(nameof(Employee))]
    [DisplayName("Специалист")]
    public int EmployeeId { get; private set; }

    [Column("work_date", TypeName = "date")]
    [DisplayName("Дата")]
    public DateTime WorkDate { get; private set; }

    [Column("work_kind")]
    [DisplayName("Виды работ")]
    public WorkKind WorkKind { get; private set; }

    [Browsable(false)]
    public Employee? Employee { get; private set; }

    [Browsable(false)]
    public ICollection<WorkTimeRecordProject> WorkTimeRecordProjects { get; private set; } = [];

    public static WorkTimeRecord CreateOperation(int id, int employeeId, DateTime workDate, WorkKind workKind,
        IEnumerable<WorkTimeRecordProject> workTimeRecordProjects)
    {
        return new WorkTimeRecord
        {
            Id = id,
            EmployeeId = employeeId,
            WorkDate = workDate.Date,
            WorkKind = workKind,
            WorkTimeRecordProjects = workTimeRecordProjects?.ToList() ?? []
        };
    }
}
