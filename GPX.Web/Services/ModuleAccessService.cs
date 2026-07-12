using System.Security.Claims;
using GPX.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GPX.Web.Services {
    public class ModuleAccessService {
        private readonly ApplicationDbContext _dbContext;
        private readonly bool _showHomePage;

        public ModuleAccessService(ApplicationDbContext dbContext, IConfiguration configuration) {
            _dbContext = dbContext;
            _showHomePage = configuration.GetValue("Navigation:ShowHomePage", true);
        }

        public bool ShowHomePage => _showHomePage;

        public async Task<IReadOnlyList<ModuleDefinition>> GetAllowedModulesAsync(ClaimsPrincipal user) {
            if(user.Identity?.IsAuthenticated != true) {
                return [];
            }

            var allowedCodes = user.FindAll(AppClaimTypes.Module)
                .Select(claim => claim.Value)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            return await _dbContext.Modules
                .AsNoTracking()
                .Where(module => module.IsEnabled && allowedCodes.Contains(module.Code))
                .OrderBy(module => module.ParentDisplayOrder)
                .ThenBy(module => module.DisplayOrder)
                .Select(module => new ModuleDefinition(
                    module.Code,
                    module.Name,
                    module.Route,
                    module.Description,
                    module.IconCssClass,
                    module.ParentCode,
                    module.ParentName,
                    module.ParentIconCssClass,
                    module.ParentDisplayOrder,
                    module.DisplayOrder))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ModuleGroupItem>> GetAllowedModuleGroupsAsync(ClaimsPrincipal user) {
            var allowedModules = await GetAllowedModulesAsync(user);
            return allowedModules
                .GroupBy(module => new ModuleGroupDefinition(
                    module.ParentCode,
                    module.ParentName,
                    module.ParentIconCssClass,
                    module.ParentDisplayOrder))
                .OrderBy(group => group.Key.DisplayOrder)
                .Select(group => new ModuleGroupItem(
                    group.Key,
                    group.OrderBy(module => module.DisplayOrder).ToList()))
                .ToList();
        }

        public string ResolveModuleName(string route, IReadOnlyList<ModuleDefinition> visibleModules) {
            var normalizedRoute = route.Trim('/');
            return visibleModules.FirstOrDefault(module =>
                    string.Equals(module.Route.Trim('/'), normalizedRoute, StringComparison.OrdinalIgnoreCase))
                ?.Name
                ?? normalizedRoute;
        }

        public string GetProfileName(ClaimsPrincipal user) =>
            user.FindFirst(AppClaimTypes.Profile)?.Value ?? "Sin perfil";

        public string GetDisplayName(ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.Name)?.Value
            ?? user.FindFirst(ClaimTypes.Email)?.Value
            ?? "Usuario";
    }

    public sealed record ModuleGroupItem(
        ModuleGroupDefinition Group,
        IReadOnlyList<ModuleDefinition> Modules);
}
