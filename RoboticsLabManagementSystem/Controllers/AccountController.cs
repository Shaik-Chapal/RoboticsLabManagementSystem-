using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using RoboticsLabManagementSystem.Api.RequestHandler.AuthRequestHandler;
using RoboticsLabManagementSystem.Application.ExternalServices;
using RoboticsLabManagementSystem.Infrastructure.Features.Membership;
using RoboticsLabManagementSystem.Infrastructure.Securities;
using RoboticsLabManagementSystem.RequestHandler;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using System.Text;

namespace RoboticsLabManagementSystem.Controllers
{
    [EnableCors("AllowSites")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AccountController> _logger;
        private readonly ICaptchaVerificationService _captchaService;
        private readonly IConfiguration _configuration;
        private readonly ILifetimeScope _scope;
        public AccountController(ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService,
            ICaptchaVerificationService captchaService,
            IConfiguration configuration,
            ILifetimeScope scope)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _captchaService = captchaService;
            _configuration = configuration;
            _scope = scope;
        }
        [HttpPost("Register")]
        [SwaggerOperation(
          Summary = "Registers a new user with the specified role",
          Description = "This endpoint allows users to register by providing their email, password, and desired role (Staff =0 or Student=1).")]
        [SwaggerResponse(StatusCodes.Status200OK, "Registration successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid registration data or invalid user role specified", typeof(IResult))]

        public async Task<IActionResult> Register([FromBody] RegisterUserRequest registerRequest)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = registerRequest.Email,
                    UserName = registerRequest.Email, 
                    PhoneNumber = registerRequest.Phone,
                    EmailConfirmed=true
                };

                var claims = new List<Claim>();
                switch (registerRequest.UserRole)
                {
                    case UserRole.Staff:
                        claims.Add(new Claim("StaffAccess", "Staff"));
                      
                        break;
                    case UserRole.Student:
                        claims.Add(new Claim("StudentAccess", "Student"));
                       
                        break;
                    case UserRole.Teacher:
                        claims.Add(new Claim("TeacherAccess", "Teacher"));

                        break;
                    default:
                        return BadRequest(new { status = "error", message = "Invalid user role specified" });
                }

                var result = await _userManager.CreateAsync(user, registerRequest.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimsAsync(user, claims);
                

       

   
                    return Ok(new { status = "Success", message = "Registration successful", userId = user.Id });

                }
                else
                {
                    return BadRequest(new { status = "error", message = "Registration failed: " + string.Join(",", result.Errors.Select(e => e.Description)) });
                }
            }

            return BadRequest(new { status = "error", message = "Invalid registration data" });
        }

        /// <summary>
        /// Verifies the captcha token for a given request.
        /// </summary>
        /// <param name="tokenRequest">The request containing the captcha token.</param>
        /// <returns>
        /// If the captcha token is valid, returns a success response with a message.
        /// If the captcha token is invalid, returns a bad request response with an error message.
        /// </returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "Token": "JEJviamMFHMTQXXct2tjMvnUQ0z3TdIexUxiAvyyLzbEzOs0J-QWoSvEBM6naocMiv"
        ///     }
        /// 
        /// Sample response for a successful verification:
        /// 
        ///     {
        ///       "status": "Success",
        ///       "message": "Captcha verification successful"
        ///     }
        /// 
        /// Sample response for a failed verification:
        /// 
        ///     {
        ///       "status": "error",
        ///       "message": "Captcha verification failed"
        ///     }
        /// </remarks>
        [SwaggerResponse(StatusCodes.Status200OK, "Captcha verification successful", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Captcha verification failed", typeof(IResult))]
        [HttpPost("VerifyCaptcha")]
        public async Task<IActionResult> VerifyCaptcha(AddTokenRequestHandler tokenRequest)
        {
            bool isValid = await _captchaService.VerifyCaptchaToken(tokenRequest.Token);

            if (isValid)
            {
                return Ok(new { status = "Success", message = "Captcha verification successful" });
            }

            return BadRequest(new { status = "error", message = "Captcha verification failed" });
        }

        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "email": "xyz@devteam.com",
        ///       "password": "123456"
        ///     }
        /// 
        /// Sample response:
        /// 
        ///     {
        ///       "status": "Success",
        ///       "message": "Login successful",
        ///       "data": {
        ///         "user": {
        ///           "id": "17fa016f-ae8b-4044-80e3-abd54djie392f",
        ///           "username": "test",
        ///           "email": "test@gmail.com",
        ///           "claims": [
        ///             {
        ///               "value": "Administrator"
        ///             }
        ///           ]
        ///         },
        ///         "token": "eyJhbGciOiJIsInR5cCI6IkpXVCJ9.eyJBZG1pbkFjY2VzcyI6IkFkbWluaXN0cmF0b3IiLCJuYmYiOjE3MDQ4MjUxNjcsImV4cCI6MTcwNTQyOTk2NywiaWF0IjoxNzA0ODI1MTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDMyMiIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzIyIn0.rRIES69wQVQUCnorcHfh6b_EneyAPn1aSjSwUhxZfF0"
        ///       }
        ///     }
        /// </remarks>
        [SwaggerOperation(
       Summary = "Check the user credentials and return the status code, token, and user information")]
        [SwaggerResponse(StatusCodes.Status200OK, "Login successful", typeof(AddLoginRequestHandler))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Request validation failed", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error occurred", typeof(IResult))]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AddLoginRequestHandler loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new { status = "error", message = "Please provide both email and password" });
            }
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                return NotFound(new { status = "error", message = "Invalid email address" });
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, true, lockoutOnFailure: true);
            if (result != null && result.Succeeded)
            {
                var claims = await _userManager.GetClaimsAsync(user);
                var token = await _tokenService.GetJwtToken(claims);

                var userData = new
                {
                    id = user.Id,
                    username = user.UserName,
                    email = user.Email,
                    claims = claims.Select(c => new { value = c.Value }),
                };

                return Ok(new
                {
                    status = "Success",
                    message = "Login successful",
                    data = new { user = userData, token }
                });
            }
            else
            {
                _logger.LogError("Failed login attempt for email {Email}. Reason: {Reason}", loginRequest.Email, result.ToString());
                return BadRequest(new { status = "error", message = "Invalid credentials" });
            }
        }

        /// <summary>
        /// Logs out the authenticated user.
        /// </summary>
        /// <returns>
        /// If the user is successfully logged out, returns a success response with a message.
        /// </returns>
        /// <remarks>
        /// This endpoint requires authentication.
        /// </remarks>
        /// <remarks>
        /// Sample response for a successful logout:
        /// 
        ///     {
        ///       "status": "Success",
        ///       "message": "Logged out successfully"
        ///     }
        /// </remarks>
        [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, "Logged out successfully", typeof(IResult))]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(new { status = "Success", message = "Logged out successfully" });
        }

        /// <summary>
        /// Initiates the process for resetting a user's forgotten password.
        /// </summary>
        /// <param name="request">The request containing the user's email for password reset.</param>
        /// <returns>
        /// If the request is valid and the user exists with a confirmed email, initiates the password reset process
        /// and returns a success response with a reset token.
        /// If the request is invalid or the user does not exist, returns a success response without initiating the process.
        /// </returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "Email": "test@example.com"
        ///     }
        /// 
        /// Sample response for a successful initiation:
        /// 
        ///     {
        ///       "ResetToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
        ///     }
        /// 
        /// </remarks>
        [SwaggerResponse(StatusCodes.Status200OK, "Password reset process initiated successfully", typeof(ForgotPasswordRequestHandler))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request. Please provide a valid email address.", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error occurred", typeof(IResult))]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestHandler request)
        {
            if (ModelState.IsValid)
            {
                request.ResolveDependency(_scope);
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    _logger.LogError($"{user} not exists");
                    return Ok();
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var passwordResetLink = Url.Link("PasswordResetRoute", new { userId = user.Id, code });
                string apiHomeUrl = _configuration["AngularProjectSettings:APIHomeURL"];
                string resetPasswordSelector = _configuration["AngularProjectSettings:ResetPasswordSelector"];
                var callbackUrl = $"{apiHomeUrl}/{resetPasswordSelector}{passwordResetLink}?token={code}&email={user.Email}";
                var _email = request.CreateEmail(user.Email, user.UserName, callbackUrl);
                request.SendPasswordResetEmail(user.UserName, user.Email, _email.Subject, _email.Body);

                return Ok(new { ResetToken = code });
            }

            return BadRequest();
        }

        /// <summary>
        /// Resets the user's password using the provided token.
        /// </summary>
        /// <param name="request">The request containing the necessary information for password reset.</param>
        /// <returns>
        /// If the request is valid and the password is successfully reset, returns a success response.
        /// If the request is invalid or the password reset fails, returns an appropriate error response.
        /// </returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "Email": "test@example.com",
        ///       "Token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9",
        ///       "NewPassword": "@#12345",
        ///       "ConfirmPassword": "@#12345"
        ///     }
        /// 
        /// Sample response for a successful password reset:
        /// 
        ///     {
        ///       "status": "Success",
        ///       "message": "Password reset successful"
        ///     }
        /// 
        /// Sample response for a failed password reset:
        /// 
        ///     {
        ///       "status": "error",
        ///       "message": "Password reset failed",
        ///       "errors": ["Error 1", "Error 2"]
        ///     }
        /// </remarks>
        [SwaggerResponse(StatusCodes.Status200OK, "Password reset successful", typeof(ResetPasswordRequestHandler))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request. Check the provided data and try again.", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error occurred", typeof(IResult))]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestHandler request)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(request.Token) ||
               string.IsNullOrEmpty(request.NewPassword) ||
               string.IsNullOrEmpty(request.ConfirmPassword))
                {
                    return BadRequest("Token, new password, and confirm password are required.");
                }

                if (request.NewPassword != request.ConfirmPassword)
                {
                    return BadRequest("Passwords do not match.");
                }

                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    _logger.LogError($"{user} not exists");
                    return Ok();
                }

                var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));
                var result = await _userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Password Reset SuccessFull!");
                    return Ok();
                }

                else
                {
                    _logger.LogError("Password Reset Failed.");
                    return BadRequest(result.Errors);
                }
            }

            return BadRequest();
        }
    }
}