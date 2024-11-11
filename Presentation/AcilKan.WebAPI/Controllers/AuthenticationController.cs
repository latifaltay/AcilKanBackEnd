using AcilKan.Application.DTOs.LoginRegisterOperations;
using AcilKan.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto, CancellationToken cancellationToken)
        {
            AppUser appUser = new()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                BloodGroup = registerDto.BloodGroup,
                Gender = registerDto.Gender,
                UserName = registerDto.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto, CancellationToken cancellationToken) 
        {
            AppUser? appUser = await _userManager.FindByIdAsync(changePasswordDto.Id.ToString());

            if (appUser == null) 
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı"});
            }

            IdentityResult result = await _userManager.ChangePasswordAsync(appUser, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

            if (!result.Succeeded) 
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();

        }


        [HttpGet]
        public async Task<IActionResult> ForgotPassword(string email, CancellationToken cancellationToken) 
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(email);

            if (appUser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            return Ok(new {Token = token});
        }


        [HttpPost]
        public async Task<IActionResult> ChangePasswordUsingToken(ChangePasswordUsingTokenDto changePasswordUsingTokenDto, CancellationToken cancellationToken) 
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(changePasswordUsingTokenDto.Email);

            if (appUser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(appUser, changePasswordUsingTokenDto.Token, changePasswordUsingTokenDto.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto, CancellationToken cancellationToken) 
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(loginDto.Email);

            if (appUser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            var  result = await _userManager.CheckPasswordAsync(appUser, loginDto.Password);

            if (!result) 
            {
                return BadRequest("Parola Yanlış!");
            }

            return Ok(new { Token = "token"});
        }


        [HttpPost]
        public async Task<IActionResult> LoginWithSignInManager(LoginDto loginDto, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(loginDto.Email);

            if (appUser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, loginDto.Password, false);

            if (!result.Succeeded) 
            {
                return BadRequest("Parola Yanlış");
            }

            return Ok(new { Token = "token" });
        }

    }
}
