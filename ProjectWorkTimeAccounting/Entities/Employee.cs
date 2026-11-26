using ProjectWorkTimeAccounting.Entities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkTimeAccounting.Entities;

// Специалист компании (менеджер или разработчик)
[Table("employees")]
public class Employee
{
    [Key]
    [Column("id")]
    public int Id { get; private set; }

    [Required]
    [Column("full_name")]
    [DisplayName("ФИО")]
    public string FullName { get; private set; } = string.Empty;

    [Column("employee_post")]
    [DisplayName("Должность")]
    public EmployeePost EmployeePost { get; private set; }

    [Column("qualification_id")]
    [ForeignKey(nameof(Qualification))]
    [DisplayName("Квалификация")]
    public int QualificationId { get; private set; }

    [Browsable(false)]
    public Qualification? Qualification { get; private set; }

    public static Employee CreateEntity(int id, string fullName, EmployeePost employeePost, int qualificationId)
    {
        return new Employee
        {
            Id = id,
            FullName = fullName ?? string.Empty,
            EmployeePost = employeePost,
            QualificationId = qualificationId
        };
    }
}
