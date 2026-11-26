using ProjectWorkTimeAccounting.Forms;
using ProjectWorkTimeAccounting.Repositories;
using ProjectWorkTimeAccounting.Repositories.Implementations;
using Unity;

namespace ProjectWorkTimeAccounting;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(CreateContainer().Resolve<FormWorkTimeAccounting>());
    }

    private static IUnityContainer CreateContainer()
    {
        var container = new UnityContainer();

        container.RegisterType<IQualificationRepository, QualificationRepository>();
        container.RegisterType<IEmployeeRepository, EmployeeRepository>();
        container.RegisterType<IProjectRepository, ProjectRepository>();
        container.RegisterType<IWorkTimeRecordRepository, WorkTimeRecordRepository>();
        container.RegisterType<ISalaryPaymentRepository, SalaryPaymentRepository>();

        return container;
    }
}
