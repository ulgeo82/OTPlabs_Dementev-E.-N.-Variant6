using ProjectWorkTimeAccounting.Entities;
using ProjectWorkTimeAccounting.Entities.Enums;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Заглушка репозитория справочника «Специалисты»
public class EmployeeRepository : IEmployeeRepository
{
    public void CreateEmployee(Employee employee)
    {
    }

    public void DeleteEmployee(int id)
    {
    }

    public Employee ReadEmployeeById(int id)
    {
        return Employee.CreateEntity(0, string.Empty, EmployeePost.None, 0);
    }

    public IEnumerable<Employee> ReadEmployees()
    {
        return [];
    }

    public void UpdateEmployee(Employee employee)
    {
    }
}
