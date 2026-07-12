using GPX.Web.Services;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;

namespace GPX.Web.Utils {
    public static class ServiceExtensions {
        public static void AddAppServices(this IServiceCollection services) {
            services.AddDevExpressBlazor();
            services.AddScoped<BrandingService>();
            services.AddScoped<GestionManagerService>();
            services.AddScoped<ModuleLoader>();
            services.AddScoped<ModuleAccessService>();
            services.AddScoped<ThemeManager>();
            services.AddScoped<SizeModeManager>();
            services.AddScoped(sp => new CascadingValueSource<SizeMode>("ParentSizeMode", SizeMode.Medium, false));
            services.AddCascadingValue(sp => sp.GetRequiredService<CascadingValueSource<SizeMode>>());
        }
    }
}
