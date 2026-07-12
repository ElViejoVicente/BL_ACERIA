namespace GPX.Web.Data {
    public sealed record ModuleDefinition(
        string Code,
        string Name,
        string Route,
        string Description,
        string IconCssClass,
        string ParentCode,
        string ParentName,
        string ParentIconCssClass,
        int ParentDisplayOrder,
        int DisplayOrder);

    public sealed record ModuleGroupDefinition(
        string Code,
        string Name,
        string IconCssClass,
        int DisplayOrder);
}
