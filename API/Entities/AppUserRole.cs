using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        [ForeignKey(nameof(User))]
        public override int UserId { get; set; }
        public AppUser User { get; set; }

        [ForeignKey(nameof(Role))]
        public override int RoleId { get; set; }
        public AppRole Role { get; set; }
    }
}