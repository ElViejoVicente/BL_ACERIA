namespace GPX.Web.Data {
    public class AppProfileModule {
        public int ProfileId { get; set; }
        public AppProfile Profile { get; set; } = default!;
        public int ModuleId { get; set; }
        public AppModule Module { get; set; } = default!;
    }
}
