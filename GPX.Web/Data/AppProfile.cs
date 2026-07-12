namespace GPX.Web.Data {
    public class AppProfile {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public ICollection<AppProfileModule> ProfileModules { get; set; } = new List<AppProfileModule>();
    }
}
