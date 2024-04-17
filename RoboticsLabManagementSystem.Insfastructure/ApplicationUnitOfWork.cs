using RoboticsLabManagementSystem.Application.UnitOfWork;
using RoboticsLabManagementSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using DevSkill.Data;

namespace RoboticsLabManagementSystem.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ICompanyRepository Company { get; private set; }
        public IBranchRepository Branches { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            ICompanyRepository companyRepository,
            IBranchRepository branchRepository,
            IApplicationUserRepository applicationUser) : base((DbContext)dbContext)
        {
            Company = companyRepository;
            Branches = branchRepository;
            ApplicationUser = applicationUser;
        }
    }
}
