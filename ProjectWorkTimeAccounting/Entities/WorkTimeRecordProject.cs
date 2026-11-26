namespace ProjectWorkTimeAccounting.Entities;

// Связка «запись учета рабочего времени — проект» (многие-ко-многим) с числом отработанных часов
public class WorkTimeRecordProject
{
    public int WorkTimeRecordId { get; private set; }

    public int ProjectId { get; private set; }

    public decimal Hours { get; private set; }

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
