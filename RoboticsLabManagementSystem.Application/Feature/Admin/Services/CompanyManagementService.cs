using DevSkill.Extensions.Paginate.Contracts;
using DevSkill.Extensions.Queryable;
using RoboticsLabManagementSystem.Application.ExternalServices;
using RoboticsLabManagementSystem.Application.UnitOfWork;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Application.Feature.Admin.Services
{
    public class CompanyManagementService : ICompanyManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
       // private readonly IFileService _fileService;

        //public CompanyManagementService(IApplicationUnitOfWork unitOfWork, IFileService fileService)
        //{
        //    _unitOfWork = unitOfWork;
        //    _fileService = fileService;
        //}
        public CompanyManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         
        }
        public async Task CreateCompany(Company company)
        {
            _unitOfWork.Company.AddAsync(company);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddBranch(Branch entity)
        {
            //var company =(await _unitOfWork.Company.GetAllAsync()).First();

            //if (company == null)
            //{
            //    throw new InvalidOperationException("Company don't exist");
            //}

            //entity.CompanyId = company.Id;

            await _unitOfWork.Branches.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateBranch(Branch entity)
        {
            var branchToUpdate = await _unitOfWork.Branches.GetByIdAsync(entity.Id);
            if (branchToUpdate == null)
            {
                throw new InvalidOperationException($"Branch with ID {entity.Id} don't exist.");
            }

            branchToUpdate.Name = entity.Name;
            branchToUpdate.Address = entity.Address;
            branchToUpdate.Phone = entity.Phone;

            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteBranch(Guid id)
        {
            if(await _unitOfWork.Branches.GetByIdAsync(id)==null)
            {
                throw new InvalidOperationException($"Branch with ID {id} don't exist.");
            }
            await _unitOfWork.Branches.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }
        public async Task<Branch> GetBranch()
        {
            return (Branch)(await _unitOfWork.Branches.GetAllAsync()).Select(x=> new Branch
            {
              
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                        

            }
                );
        }

        public async Task<IPaginate<Branch>> GetBranches(SearchRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Branches.GetPaginateBranch(request, cancellationToken);
        }

        public async Task<Company> GetCompany()
        {
            return (await _unitOfWork.Company.GetAllAsync()).Select(x => new Company
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                Email= x.Email,
                OpenTime = x.OpenTime,
                CloseTime   = x.CloseTime,
                LogoUrl = "",
                Website = x.Website,
            }).First();
        }

        public async Task UpdateCompany(Company entity)
        {
            var companyToUpdate = await _unitOfWork.Company.GetByIdAsync(entity.Id);

            if (companyToUpdate == null)
            {
                throw new InvalidOperationException($"Company with ID {entity.Id} was not found.");
            }
            //if (!string.IsNullOrWhiteSpace(entity.LogoUrl) && entity.LogoUrl!=null)
            //{
            //    if(companyToUpdate.LogoUrl!=null)
            //    {
            //        await _fileService.DeleteFile(companyToUpdate.LogoUrl);
            //    }
            //    companyToUpdate.LogoUrl= await _fileService.UploadFile(entity.LogoUrl, "LogoImage");
            //}

            companyToUpdate.Name = entity.Name;
            companyToUpdate.Email = entity.Email;
            companyToUpdate.Phone = entity.Phone;
            companyToUpdate.Address = entity.Address;
            companyToUpdate.Website = entity.Website;

            await _unitOfWork.SaveAsync();
        }
    }
}
