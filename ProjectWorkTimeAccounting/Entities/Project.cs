using ProjectWorkTimeAccounting.Entities.Enums;
using System.ComponentModel;

namespace ProjectWorkTimeAccounting.Entities;

// Проект компании, на который назначены менеджер и разработчик
public class Project
{
    public int Id { get; private set; }

    [DisplayName("Название")]
    public string Name { get; private set; } = string.Empty;

    [DisplayName("Тип проекта")]
    public ProjectType ProjectType { get; private set; }

    [DisplayName("Менеджер")]
    public int ManagerId { get; private set; }

    [DisplayName("Разработчик")]
    public int DeveloperId { get; private set; }

    [DisplayName("Дата начала")]
    public DateTime StartDate { get; private set; }

    public static Project CreateEntity(int id, string name, ProjectType projectType, int managerId,
        int developerId, DateTime startDate)
    {
        return new Project
        {
            Id = id,
            Name = name ?? string.Empty,
            ProjectType = projectType,
            ManagerId = managerId,
            DeveloperId = developerId,
            StartDate = startDate
        };
    }
}
