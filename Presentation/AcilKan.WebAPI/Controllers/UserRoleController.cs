using AcilKan.Domain.Entities;
using AcilKan.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController(AcilKanContext context, UserManager<AppUser> _userManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Create(int userId, string roleName, int roleId, CancellationToken cancellationToken)
        {
            //AppUserRole appUserRole = new()
            //{
            //    UserId = userId,
            //    RoleId = roleId,
            //};

            //await context.UserRoles.AddAsync(appUserRole);

            //await context.SaveChangesAsync(cancellationToken);

            AppUser? appUser = await _userManager.FindByIdAsync(userId.ToString());
            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı bulunamadı" });
            }

            IdentityResult result = await _userManager.AddToRoleAsync(appUser, roleName);


            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(s => s.Description));
            }
            return NoContent();
        }
    }
}
