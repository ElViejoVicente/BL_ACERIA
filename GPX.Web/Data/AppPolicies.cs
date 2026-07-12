namespace GPX.Web.Data {
    public static class AppPolicies {
        public const string ModulePrefix = "Module:";
        public const string PermissionPrefix = "Permission:";

        public const string PlanningApprovalPermission = "planning:approve";
        public const string ManufacturingReleasePermission = "manufacturing:release";

        public static string Module(string moduleCode) => $"{ModulePrefix}{moduleCode}";
        public static string Permission(string permissionCode) => $"{PermissionPrefix}{permissionCode}";
    }
}
