namespace GPX.Web {
    public class UserInfo {
        public required string UserId { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
        public string Profile { get; set; } = string.Empty;
    }
}
