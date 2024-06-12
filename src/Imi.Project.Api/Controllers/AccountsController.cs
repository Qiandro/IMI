using FluentValidation;
using FluentValidation.Results;
using Imi.Project.Api.Core.Dtos.Accounts;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Imi.Project.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IValidator<LoginRequestDto> _loginValidator;

        private DateTime seedingDate = new DateTime(1970, 01, 01);

        public AccountsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration, IValidator<LoginRequestDto> loginValidator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _loginValidator = loginValidator;
        }

        [AllowAnonymous]
        [HttpPost("auth/login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ValidationResult validationResult = _loginValidator.Validate(loginRequestDto);

            if (validationResult.IsValid)
            {
                var user  = await _userManager.FindByEmailAsync(loginRequestDto.Email);
                if (user == null)
                {
                    return BadRequest("There is no user with username " +  loginRequestDto.Email);
                }

                var signInResult = await _signInManager.PasswordSignInAsync(user, loginRequestDto.Password, false, false);
                if (signInResult.Succeeded)
                {
                    JwtSecurityToken token = await GenerateTokenAsync(user);
                    string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
                    //serialize the token


                    return Ok(new LoginUserResponseDto() { Token = serializedToken });
                }
                else
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("auth/register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            var user = new ApplicationUser
            {
                Email = dto.Email,
                NormalizedEmail = dto.Email.ToUpper(),
                UserName = dto.Email,
                NormalizedUserName = dto.Email.ToUpper(),
                BirthDate = seedingDate,
                HasApprovedTermsAndConditions = dto.AcceptTermsAndConditions,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        await _userManager.CreateAsync(user, dto.Password);
            return Ok();
    }

    private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>();

            // Loading the user Claims
            var userClaims = await _userManager.GetClaimsAsync(user);

            claims.AddRange(userClaims);

            // Loading the roles and put them in a claim of a Role ClaimType
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var roleClaim in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleClaim));
            }

            claims.Add(new Claim(MyOwnClaimTypes.TaC, user.HasApprovedTermsAndConditions.ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));




            var expirationDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
            var siginingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
            var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)), notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(siginingKey), SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
