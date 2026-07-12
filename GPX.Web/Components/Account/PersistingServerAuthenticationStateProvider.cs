using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using GPX.Web;
using GPX.Web.Data;

namespace GPX.Web.Components.Account {
    // This provider persists minimal user data for interactive rendering.
    internal sealed class PersistingServerAuthenticationStateProvider : ServerAuthenticationStateProvider, IDisposable {
        private readonly PersistentComponentState state;
        private readonly IdentityOptions options;

        private readonly PersistingComponentStateSubscription subscription;

        private Task<AuthenticationState>? authenticationStateTask;

        public PersistingServerAuthenticationStateProvider(
            PersistentComponentState persistentComponentState,
            IOptions<IdentityOptions> optionsAccessor) {
            state = persistentComponentState;
            options = optionsAccessor.Value;

            AuthenticationStateChanged += OnAuthenticationStateChanged;
            subscription = state.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveServer);
        }

        private void OnAuthenticationStateChanged(Task<AuthenticationState> task) {
            authenticationStateTask = task;
        }

        private async Task OnPersistingAsync() {
            if(authenticationStateTask is null) {
                throw new UnreachableException($"Authentication state not set in {nameof(OnPersistingAsync)}().");
            }

            var authenticationState = await authenticationStateTask;
            var principal = authenticationState.User;

            if(principal.Identity?.IsAuthenticated == true) {
                var userId = principal.FindFirst(options.ClaimsIdentity.UserIdClaimType)?.Value;
                var email = principal.FindFirst(options.ClaimsIdentity.EmailClaimType)?.Value;
                var name = principal.FindFirst(options.ClaimsIdentity.UserNameClaimType)?.Value;
                var role = principal.FindFirst(options.ClaimsIdentity.RoleClaimType)?.Value ?? "Guest";
                var profile = principal.FindFirst(AppClaimTypes.Profile)?.Value ?? string.Empty;

                if(userId != null && email != null && name != null && role != null) {
                    state.PersistAsJson(nameof(UserInfo), new UserInfo {
                        UserId = userId,
                        Email = email,
                        Name = name,
                        Role = role,
                        Profile = profile
                    });
                }
            }
        }

        public void Dispose() {
            subscription.Dispose();
            AuthenticationStateChanged -= OnAuthenticationStateChanged;
        }
    }
}
