using ProjectWorkTimeAccounting.Entities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkTimeAccounting.Entities;

// Проект компании, на который назначены менеджер и разработчик
[Table("projects")]
public class Project
{
    [Key]
    [Column("id")]
    public int Id { get; private set; }

    [Required]
    [Column("name")]
    [DisplayName("Название")]
    public string Name { get; private set; } = string.Empty;

    [Column("project_type")]
    [DisplayName("Тип проекта")]
    public ProjectType ProjectType { get; private set; }

    [Column("manager_id")]
    [ForeignKey(nameof(Manager))]
    [DisplayName("Менеджер")]
    public int ManagerId { get; private set; }

    [Column("developer_id")]
    [ForeignKey(nameof(Developer))]
    [DisplayName("Разработчик")]
    public int DeveloperId { get; private set; }

    [Column("start_date", TypeName = "date")]
    [DisplayName("Дата начала")]
    public DateTime StartDate { get; private set; }

    [Browsable(false)]
    public Employee? Manager { get; private set; }

    [Browsable(false)]
    public Employee? Developer { get; private set; }

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
            StartDate = startDate.Date
        };
    }
}
