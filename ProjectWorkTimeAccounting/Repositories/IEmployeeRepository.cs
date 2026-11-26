using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting.Repositories;

// Репозиторий справочника «Специалисты»
public interface IEmployeeRepository
{
    IEnumerable<Employee> ReadEmployees();

    Employee ReadEmployeeById(int id);

    void CreateEmployee(Employee employee);

    void UpdateEmployee(Employee employee);

    void DeleteEmployee(int id);
}
