using Microsoft.AspNetCore.Mvc;
using RoboticsLabManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Domain.Entities.Company;
using Microsoft.AspNetCore.Identity;
using RoboticsLabManagementSystem.Infrastructure.Features.Membership;
using System.Security.Claims;
using RoboticsLabManagementSystem.Dto;


namespace RoboticsLabManagementSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        //StudentAccess
        [HttpGet("AllStudent")]
        public IActionResult GetAllStudent()
        {
            var teachers = _context.Users
                .Join(_context.UserClaims, u => u.Id, uc => uc.UserId, (u, uc) => new { User = u, Claim = uc })
                .Where(x => x.Claim.ClaimType == "StudentAccess" )
                .Select(x => new
                {
                    Id = x.User.Id,
                    UserName = x.User.FirstName + " " + x.User.LastName,
                    Uid = x.User.IdNumber,
                    Status = x.User.Status,
                    Session = x.User.Session,
                })
                .ToList();

            return Ok(teachers);
        }

        [HttpGet("AllStaff")]
        public IActionResult GetAllStaff()
        {
            var teachers = _context.Users
                .Join(_context.UserClaims, u => u.Id, uc => uc.UserId, (u, uc) => new { User = u, Claim = uc })
                .Where(x => x.Claim.ClaimType == "StaffAccess")
                .Select(x => new
                {
                    Id = x.User.Id,
                    UserName = x.User.FirstName + " " + x.User.LastName,
                    Uid = x.User.IdNumber,
                    Status = x.User.Status,
                    Session = x.User.Session,
                })
                .ToList();

            return Ok(teachers);
        }


        [HttpGet("AllTeacher")]
        public IActionResult GetAllTeachers()
        {
            var teachers = _context.Users
                .Join(_context.UserClaims, u => u.Id, uc => uc.UserId, (u, uc) => new { User = u, Claim = uc })
                .Where(x => x.Claim.ClaimType == "TeacherAccess" )
                .Select(x => new
                {
                    Id = x.User.Id,
                    UserName = x.User.FirstName + " " + x.User.LastName,
                    Uid = x.User.IdNumber,
                    Status = x.User.Status,
                    Session = x.User.Session,
                })
                .ToList();

            return Ok(teachers);
        }


        [HttpPost("ActivateTeacher/{id}")]
        public async Task<IActionResult> ActivateTeacher(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Status = "active";
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("DeactivateTeacher/{id}")]
        public async Task<IActionResult> DeactivateTeacher(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Status = "inactive";
            await _context.SaveChangesAsync();

            return Ok(user);
        }
        [HttpGet("AllUser")]
        public IActionResult AllUser()
        {
            var teachers = _context.ApplicationUser
                .Join(_context.UserClaims, u => u.Id, uc => uc.UserId, (u, uc) => new { User = u, Claim = uc })
               
                .Select(x => new
                {
                    Id = x.User.Id,
                    UserName = x.User.UserName,

                })
                .ToList();

            return Ok(teachers);
        }


        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        // GET: api/User
        [HttpGet("Department")]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranchs()
        {
            return await _context.Branch.ToListAsync();
        }
        // PUT: api/Companies/5
        [HttpPut("University/{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UniversityUpdateDto companyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            company.Name = companyDto.Name;
            company.Email = companyDto.Email;
            company.Phone = companyDto.Phone;
            company.Address = companyDto.Address;
            company.OpenTime = companyDto.OpenTime;
            company.CloseTime = companyDto.CloseTime;
            company.LogoUrl = companyDto.LogoUrl;
            company.Website = companyDto.Website;

            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }

}
