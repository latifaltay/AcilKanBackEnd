using AcilKan.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController(RoleManager<AppRole> _roleManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CreateAppRole(string name, CancellationToken cancellationToken) 
        {
            AppRole appRole = new() 
            {
                Name = name,    
            };

            IdentityResult result = await _roleManager.CreateAsync(appRole);

            if (!result.Succeeded) 
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();

        }


        [HttpGet]
        public async Task<IActionResult> GetAllAppRole(CancellationToken cancellationToken) 
        {
            var roles = await _roleManager.Roles.ToListAsync(cancellationToken);
            return Ok(roles);
        }


    }
}
