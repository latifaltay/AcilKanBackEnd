using AcilKan.Application.DTOs.LoginRegisterOperations;
using AcilKan.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(UserManager<AppUser> _userManager) : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDto registerDto, CancellationToken cancellationToken)
        //{
        //    AppUser appUser = new() 
        //    {
        //        Name = registerDto.UserName,
        //        Surname = registerDto.UserName,
        //        Email = registerDto.Email,
        //        PhoneNumber = registerDto.PhoneNumber,
        //        BloodGroup = registerDto.BloodGroup,
        //        Gender = registerDto.Gender,
        //        UserName = registerDto.UserName,
        //    };

        //    IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);

        //    if (!result.Succeeded) 
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //    return NoContent();
        //}


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
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

    }
}
