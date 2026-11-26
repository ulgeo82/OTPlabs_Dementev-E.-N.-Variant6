using ProjectWorkTimeAccounting.Entities.Enums;
using System.ComponentModel;

namespace ProjectWorkTimeAccounting.Entities;

// Специалист компании (менеджер или разработчик)
public class Employee
{
    public int Id { get; private set; }

    [DisplayName("ФИО")]
    public string FullName { get; private set; } = string.Empty;

    [DisplayName("Должность")]
    public EmployeePost EmployeePost { get; private set; }

    [DisplayName("Квалификация")]
    public int QualificationId { get; private set; }

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
