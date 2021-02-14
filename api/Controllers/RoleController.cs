using System.Threading.Tasks;
using api.Contracts;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("roles")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            var result = await _roleService.CreateRoleAsync(name);
            return StatusCode(result.StatusCode, result);
        }

        public async Task<IActionResult> Delete([FromBody] string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}