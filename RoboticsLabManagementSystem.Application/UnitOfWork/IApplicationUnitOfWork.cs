using DevSkill.Data;
using RoboticsLabManagementSystem.Domain.Repositories;

namespace RoboticsLabManagementSystem.Application.UnitOfWork
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Company { get; }
        IBranchRepository Branches { get; }
        IApplicationUserRepository ApplicationUser { get; }
    }
}