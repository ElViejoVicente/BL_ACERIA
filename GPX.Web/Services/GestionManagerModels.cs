using System.ComponentModel.DataAnnotations;

namespace GPX.Web.Services {
    public sealed record GestionDashboardSummary(
        int UsersCount,
        int RolesCount,
        int ProfilesCount,
        int ModulesCount,
        int RoleClaimsCount,
        int UserClaimsCount);

    public sealed record GestionModuleOption(
        int Id,
        string Code,
        string Name,
        string Route,
        string ParentCode,
        string ParentName,
        int ParentDisplayOrder,
        int DisplayOrder);

    public sealed record GestionUserListItem(
        string Id,
        string FullName,
        string Email,
        string ProfileName,
        bool EmailConfirmed,
        IReadOnlyList<string> Roles,
        IReadOnlyList<string> Permissions);

    public sealed record GestionRoleListItem(
        string Id,
        string Name,
        int UserCount,
        IReadOnlyList<string> Permissions);

    public sealed record GestionRoleUsersItem(
        string RoleId,
        string RoleName,
        IReadOnlyList<string> Permissions,
        IReadOnlyList<GestionRoleUserItem> Users);

    public sealed record GestionRoleUserItem(
        string UserId,
        string FullName,
        string Email,
        string ProfileName);

    public sealed record GestionClaimsUserItem(
        string UserId,
        string FullName,
        string Email,
        string ProfileName,
        IReadOnlyList<string> Roles,
        IReadOnlyList<string> Permissions);

    public sealed record GestionClaimsRoleItem(
        string RoleId,
        string RoleName,
        int UserCount,
        IReadOnlyList<string> Permissions);

    public sealed record GestionClaimsSummary(
        IReadOnlyList<GestionClaimsUserItem> Users,
        IReadOnlyList<GestionClaimsRoleItem> Roles);

    public sealed record GestionProfileListItem(
        int Id,
        string Name,
        string Description,
        int UserCount,
        IReadOnlyList<string> Modules);

    public sealed record GestionProfileModuleGroup(
        string ParentCode,
        string ParentName,
        IReadOnlyList<GestionSelectableModule> Modules);

    public sealed class GestionOperationResult {
        public bool Succeeded { get; init; }
        public string Message { get; init; } = string.Empty;
        public IReadOnlyList<string> Errors { get; init; } = [];

        public static GestionOperationResult Success(string message) => new() {
            Succeeded = true,
            Message = message
        };

        public static GestionOperationResult Failure(string message, IEnumerable<string>? errors = null) => new() {
            Succeeded = false,
            Message = message,
            Errors = errors?.ToList() ?? []
        };
    }

    public sealed class GestionUserEditor {
        public string? Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato valido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecciona un perfil.")]
        public int? ProfileId { get; set; }

        public bool EmailConfirmed { get; set; } = true;
        public string Password { get; set; } = string.Empty;
        public string PermissionsText { get; set; } = string.Empty;
        public List<GestionSelectableRole> Roles { get; set; } = [];
    }

    public sealed class GestionSelectableRole {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }

    public sealed class GestionRoleEditor {
        public string? Id { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        public string Name { get; set; } = string.Empty;

        public string PermissionsText { get; set; } = string.Empty;
    }

    public sealed class GestionProfileEditor {
        public int? Id { get; set; }

        [Required(ErrorMessage = "El nombre del perfil es obligatorio.")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }

    public sealed class GestionProfileModulesEditor {
        [Required(ErrorMessage = "Selecciona un perfil.")]
        public int? ProfileId { get; set; }

        public string ProfileName { get; set; } = string.Empty;
        public List<GestionSelectableModule> Modules { get; set; } = [];
    }

    public sealed class GestionSelectableModule {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string ParentCode { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;
        public int ParentDisplayOrder { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsSelected { get; set; }
        public string RouteLabel => string.IsNullOrWhiteSpace(Route) ? "Sin ruta" : Route;
    }
}
