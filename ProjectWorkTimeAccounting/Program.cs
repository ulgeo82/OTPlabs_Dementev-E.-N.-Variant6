using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectWorkTimeAccounting.Forms;
using ProjectWorkTimeAccounting.Repositories;
using ProjectWorkTimeAccounting.Repositories.Implementations;
using Serilog;
using Unity;
using Unity.Microsoft.Logging;

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

        container.AddExtension(new LoggingExtension(CreateLoggerFactory()));

        container.RegisterType<DataContext>();

        container.RegisterType<IQualificationRepository, QualificationRepository>();
        container.RegisterType<IEmployeeRepository, EmployeeRepository>();
        container.RegisterType<IProjectRepository, ProjectRepository>();
        container.RegisterType<IWorkTimeRecordRepository, WorkTimeRecordRepository>();
        container.RegisterType<ISalaryPaymentRepository, SalaryPaymentRepository>();

        return container;
    }

    private static LoggerFactory CreateLoggerFactory()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var loggerFactory = new LoggerFactory();
        loggerFactory.AddSerilog(new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger());

        return loggerFactory;
    }
}
