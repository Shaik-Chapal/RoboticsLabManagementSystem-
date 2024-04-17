using Autofac;
using RoboticsLabManagementSystem.Application.Feature.Admin.Services;

namespace RoboticsLabManagementSystem.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManagementService>().As<ICompanyManagementService>()
                .InstancePerLifetimeScope();
        }
    }
}