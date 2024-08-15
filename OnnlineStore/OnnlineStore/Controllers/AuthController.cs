using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnnlineStore.Models.DTO;
using OnnlineStore.Repositories;

namespace OnnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var user = new IdentityUser { UserName = registerRequestDto.UserName, Email = registerRequestDto.UserName };

            var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            //Asign roles
            await _userManager.AddToRolesAsync(user, registerRequestDto.Roles);
            return Ok("User registered successfully");
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginRequestDto.UserName, loginRequestDto.Password, false, false);
            if (!result.Succeeded)
            {

                return Unauthorized("Invalid login attempt!");
            }

            var user = await _userManager.FindByNameAsync(loginRequestDto.UserName);
            var roles = await _userManager.GetRolesAsync(user);

            var token = await _tokenRepository.CreateJwtTokenAsync(user, roles.ToList());

            return Ok(new { Token = token });
        }
    }
}