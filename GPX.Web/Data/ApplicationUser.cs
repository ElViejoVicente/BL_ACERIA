using Microsoft.AspNetCore.Identity;

namespace GPX.Web.Data {
    public class ApplicationUser : IdentityUser {
        public string FullName { get; set; } = string.Empty;
        public int? ProfileId { get; set; }
        public AppProfile? Profile { get; set; }
    }
}
