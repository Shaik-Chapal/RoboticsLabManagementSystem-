using Autofac;
using RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler;
using RoboticsLabManagementSystem.Api.RequestHandler.CompanyHandler;
using RoboticsLabManagementSystem.Api.RequestHandler.AuthRequestHandler;

namespace RoboticsLabManagementSystem.Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetCompanyRequestHandler>().AsSelf();
            builder.RegisterType<UpdateCompanyRequestHandler>().AsSelf();

            builder.RegisterType<GetBranchRequestHandler>().AsSelf();
            builder.RegisterType<AddBranchRequestHandler>().AsSelf();
            builder.RegisterType<CreateCompanyRequestHandler>().AsSelf();
            builder.RegisterType<UpdateBranchRequestHandler>().AsSelf();
            builder.RegisterType<DeleteBranchRequestHandler>().AsSelf();

            builder.RegisterType<ForgotPasswordRequestHandler>().AsSelf();
            builder.RegisterType<ResetPasswordRequestHandler>().AsSelf();

            base.Load(builder);
        }
    }
}