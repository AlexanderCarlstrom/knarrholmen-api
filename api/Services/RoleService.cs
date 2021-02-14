using System.Linq;
using System.Threading.Tasks;
using api.Contracts.Responses;
using Microsoft.AspNetCore.Identity;

namespace api.Services
{
    public interface IRoleService
    {
        Task<ApiResponse> CreateRoleAsync(string name);
        Task<ApiResponse> DeleteRoleAsync(string id);
    }

    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ApiResponse> CreateRoleAsync(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            if (role != null) return new ApiResponse(400, name + " role already exist");

            var newRole = new IdentityRole(name);
            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded) return new ApiResponse(true, 201);

            var errors = result.Errors.Select(err => err.Description);
            return new ApiResponse(500, "Could not create role", errors);
        }

        public async Task<ApiResponse> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return new ApiResponse(400, "Role does not exist");

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded) return new ApiResponse(true, 200);

            var response = new ApiResponse(400, "Could not create role");
            response.Errors = result.Errors.Select(err => err.Description);
            return response;
        }
    }
}