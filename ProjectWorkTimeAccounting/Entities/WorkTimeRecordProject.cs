using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkTimeAccounting.Entities;

// Связка «запись учета рабочего времени — проект» (многие-ко-многим) с числом отработанных часов
[Table("work_time_record_projects")]
public class WorkTimeRecordProject
{
    [Column("work_time_record_id")]
    [ForeignKey(nameof(WorkTimeRecord))]
    public int WorkTimeRecordId { get; private set; }

    [Column("project_id")]
    [ForeignKey(nameof(Project))]
    public int ProjectId { get; private set; }

    [Column("hours", TypeName = "numeric(5,2)")]
    public decimal Hours { get; private set; }

    public WorkTimeRecord? WorkTimeRecord { get; private set; }

    public Project? Project { get; private set; }

    public static WorkTimeRecordProject CreateElement(int workTimeRecordId, int projectId, decimal hours)
    {
        return new WorkTimeRecordProject
        {
            WorkTimeRecordId = workTimeRecordId,
            ProjectId = projectId,
            Hours = hours
        };
    }
}
