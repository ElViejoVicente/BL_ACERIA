using Microsoft.Extensions.Configuration;

namespace GPX.Web.Services {
    public class BrandingService {
        private readonly BrandingConfiguration _brandingConfiguration;

        public BrandingService(IConfiguration configuration) {
            _brandingConfiguration = configuration.GetSection("Branding").Get<BrandingConfiguration>() ?? new BrandingConfiguration();
        }

        public BrandingConfiguration Current => _brandingConfiguration;
        public string BrandCaption => string.IsNullOrWhiteSpace(_brandingConfiguration.SubCompanyDisplayName)
            ? _brandingConfiguration.ProductName
            : $"{_brandingConfiguration.ProductName} - {_brandingConfiguration.SubCompanyDisplayName}";
        public bool IsMicrosoft365SsoEnabled => _brandingConfiguration.EnableMicrosoft365Sso;
        public bool ShowHamburgerMenu => _brandingConfiguration.HamburgerMenu;

        public string GetSubCompanyLogoPath() => _brandingConfiguration.SubCompanyLogoKey.ToLowerInvariant() switch {
            "balboa" => "logos/balboa.png",
            "perseida" => "logos/perseida.png",
            "perseidabelleza" => "logos/perseida.png",
            "aceria" => "logos/aceria.png",
            _ => "logos/agsa.png"
        };

        public string GetGroupLogoPath(bool isDarkTheme) =>
            isDarkTheme ? _brandingConfiguration.GroupLogoDarkPath : _brandingConfiguration.GroupLogoLightPath;

        public string GetLoginBackgroundStyle() {
            var overlayPercent = Math.Clamp(_brandingConfiguration.LoginBackgroundOverlayPercent, 0, 100);
            var overlay = overlayPercent / 100d;
            var backgroundImage = string.IsNullOrWhiteSpace(_brandingConfiguration.LoginBackgroundImagePath)
                ? "none"
                : $"url('{_brandingConfiguration.LoginBackgroundImagePath}')";

            return string.Create(
                System.Globalization.CultureInfo.InvariantCulture,
                $"""
                --login-overlay-opacity: {overlay:0.##};
                --login-background-image: {backgroundImage};
                """);
        }

        public sealed class BrandingConfiguration {
            public string GroupLogoLightPath { get; set; } = "logos/clGrupoBlack.png";
            public string GroupLogoDarkPath { get; set; } = "logos/clGrupoWhite.png";
            public string GroupName { get; set; } = "CL Grupo Industrial";
            public string ProductName { get; set; } = "GPX";
            public string SubCompanyLogoKey { get; set; } = "agsa";
            public string SubCompanyDisplayName { get; set; } = "AGSA";
            public string WelcomeText { get; set; } = "Acceso corporativo";
            public bool EnableMicrosoft365Sso { get; set; } = true;
            public bool HamburgerMenu { get; set; } = true;
            public string LoginBackgroundImagePath { get; set; } = "";
            public int LoginBackgroundOverlayPercent { get; set; } = 58;
        }
    }
}
