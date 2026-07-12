using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace GPX.Web.Data {
    public class AppAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : DefaultAuthorizationPolicyProvider(options) {
        public override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName) {
            if(policyName.StartsWith(AppPolicies.ModulePrefix, StringComparison.OrdinalIgnoreCase)) {
                var moduleCode = policyName[AppPolicies.ModulePrefix.Length..];
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireClaim(AppClaimTypes.Module, moduleCode)
                    .Build();
                return Task.FromResult<AuthorizationPolicy?>(policy);
            }

            if(policyName.StartsWith(AppPolicies.PermissionPrefix, StringComparison.OrdinalIgnoreCase)) {
                var permissionCode = policyName[AppPolicies.PermissionPrefix.Length..];
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireClaim(AppClaimTypes.Permission, permissionCode)
                    .Build();
                return Task.FromResult<AuthorizationPolicy?>(policy);
            }

            return base.GetPolicyAsync(policyName);
        }
    }
}
